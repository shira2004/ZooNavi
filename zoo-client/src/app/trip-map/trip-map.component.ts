import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { GoogleMap, GoogleMapsModule, MapInfoWindow, MapMarker } from '@angular/google-maps';

import { Cage } from '../models/cage.model';
import { Animal } from '../models/animal.model';

import { CageService } from '../services/cage.service';
import { RiddleService } from '../services/riddle.service';
import { LocationService } from '../services/location.service';

import { RiddleDialogComponent } from '../dialogs/components/riddle-dialog/riddle-dialog.component';
import { DialogComponent } from '../dialogs/components/dialog/dialog.component';
import { AnimalService } from './../services/animal.service';
import { APP_ROUTES } from '../app_routes';
import { UserService } from '../services/user.service';
import { environment } from '../../environment';

@Component({
  selector: 'app-trip-map',
  standalone: true,
  imports: [
     GoogleMapsModule,
     CommonModule, 
     HttpClientModule
    ],
  templateUrl: './trip-map.component.html',
  styleUrl: './trip-map.component.css'
})
export class TripMapComponent {

  directionsService = new google.maps.DirectionsService();
  directionsRenderer = new google.maps.DirectionsRenderer();
  @ViewChild('mapElement') mapElement!: GoogleMap | undefined;

  getDirectionsFromMap(map: google.maps.Map) {
    if (map) {

    } else {
      console.error('Map element not found');
    }
  }


  chosenCages!: Cage[]
  correctAnswer!: number
  public cageList!: Cage[];
  public animalList!: Animal[];
  user: any;
  private geolocationSubscription!: Subscription;
  focus: boolean=false;
  center: google.maps.LatLngLiteral = {
    lat: 31.746375076233548,
    lng: 35.17735946165279
  };
  public currentUtterance: SpeechSynthesisUtterance | null = null;
  public isSpeaking: boolean = false;
  currentPlaybackPosition: number | null = null;


  constructor(
    private locationService: LocationService,
    private _cageService: CageService,
    private http: HttpClient,
    private _animalService: AnimalService,
    private _riddleService: RiddleService,
    public dialog: MatDialog,
    public dialog2: MatDialog,
    private router: Router,
    private _userService: UserService,
    private route: ActivatedRoute
    ) { }

  dialogData1 = {
    text1: 'Congratulations!',
    text2: 'Youve solved the riddle correctly! You earned a point in your personal area.',
    imageSrc: '../../../../assets/images/good.gif',
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.HOME]);
        console.log('OK button clicked');
      },
    },
  };
  dialogData2 = {
    text1: 'Better Luck Next Time!',
    text2: 'Sorry, thats not the correct answer. Keep trying to earn points in your personal area.',
    status:1,
    imageSrc: '../../../../assets/images/good.gif',
    button: {
      label: 'OK',
      onClick: () => {
        this.router.navigate([APP_ROUTES.HOME]);
        console.log('OK button clicked');
      },
    },
  };

  ngAfterViewInit(): void {
    if (this.mapElement) {

      this.directionsRenderer.setMap(this.mapElement.googleMap!);
    } else {
      console.log('Google Map instance not found');
    }
  }

  ngOnInit() {
    if (this.mapElement) {
      this.directionsRenderer.setMap(this.mapElement.googleMap!);
    } else {
      console.log('Google Map instance not found');
    }

    if (typeof localStorage !== 'undefined') {
      const currentUser = localStorage.getItem('CURRENT_USER');
      if (currentUser) {
        this.user = JSON.parse(currentUser);
      }

    }
    this.route.queryParams.subscribe(params => {
      const animalsQueryParam = params['cages'];
      if (animalsQueryParam) {
        const cagesIds = animalsQueryParam.split(',').map(Number);
        if (cagesIds.length === 0) {
          console.error('No cage IDs found in query parameter');
          return;
        }

        this._cageService.getCagesByIds(cagesIds).subscribe({
          next: (res) => {
            console.log('cages:', res);
            this.chosenCages = res;
            this.calculateAndDisplayRoute();

          },
          error: (err) => {
            console.log(err);
          }
        });
      } else {
        console.error('No animals query parameter found');
      }
    });
    this.geolocationSubscription = this.locationService.watchPosition(this.markerPositions, 2).subscribe(
      (position) => {
        this.center = { lat: position.lat, lng: position.lng };
        const marker = {
          position: this.center,
          label: {
            description: 'Your Location',
            text: this.user.userName || 'Your Location',
            color: 'blue',
            id: -1,
            fontWeight: 'bold',
            image: this.user.userImage || '',
            animalData: []
          }
        };
        this.markerPositions.push(marker);
       
      },
      (error) => {
        console.error('Error getting user position:', error);
      }
    );

    this._cageService.getAllCagesByServer().subscribe({
      next: (cages) => {
        this.cageList = cages;
        console.log(cages);

        this._animalService.getAllAnimalsByServer().subscribe({
          next: (animals) => {
            this.animalList = animals;
            
           
            this.cageList.forEach((cage) => {
              const animalsInCage = this.animalList.filter(animal => animal.cageId === cage.cageID);
              animalsInCage.forEach(animal => {
                const position: google.maps.LatLngLiteral = { lat: cage.latitude, lng: cage.longitude };
                const markerInfo = {
                  position: position,
                  label: {
                    text: animal.name,
                    color: 'black',
                    fontWeight: 'bold',
                    id: animal.animalId,
                    animalData: [{
                      name: animal.name,
                      image: animal.image || '',
                      description: animal.description,
                      id: animal.animalId
                    }],
                    image: animal.image || '',
                    description: animal.description,
                  }
                };
                this.markerPositions.push(markerInfo);
              });
            });
          },
          error: (err) => {
            console.log(err);
          }
        });
      },
      error: (err) => {
        console.log(err);
      }
    });


  }

  ngOnDestroy(): void {
    if (this.geolocationSubscription) {
      this.geolocationSubscription.unsubscribe();
    }
  }

  calculateAndDisplayRoute(): void {
    console.log(this.chosenCages);

    if (!this.chosenCages || this.chosenCages.length === 0) {
      console.error('Cage IDs are undefined or empty');
      return;
    }

    const waypoints = this.chosenCages.map(cage => ({
      location: { lat: cage.latitude, lng: cage.longitude },
      stopover: true
    }));

    const destination = { lat: 31.745937, lng: 35.177258 };

    const request = {
      origin: this.center,
      destination: destination,
      waypoints: waypoints,
      optimizeWaypoints: true,
      travelMode: google.maps.TravelMode.WALKING,
    };

    this.directionsService.route(request, (response, status) => {
      if (status === 'OK') {
        this.directionsRenderer.setDirections(response);
        console.log('Directions result:', response);
      } else {
        window.alert('Directions request failed due to ' + status);
      }
    });
  }
  @ViewChild(MapInfoWindow) infoWindow: MapInfoWindow | undefined;
  markerPositions: {
    position: google.maps.LatLngLiteral;
    label: {
      description: string;
      text: string;
      color: string;
      id: number;
      fontWeight: string;
      image: string;
      animalData: { name: string; image: string; description: string; id: number }[];
    }
  }[] = [];
  zoom = 15;
  openInfoWindow(marker: MapMarker) {
    if (this.infoWindow != undefined) this.infoWindow.open(marker);
  }


  currentAudio: HTMLAudioElement | null = null;
  speakTextInfo(markerInfo: any): void {
    if (this.isSpeaking) {
      console.log("speech is already in progress, return without executing further code");    
      return;
    }
  
    console.log(markerInfo.label.description);
  
    const requestBody = {
      input: { text: markerInfo.label.description },
      voice: { languageCode: 'en-US', name: 'en-US-Wavenet-D', ssmlGender: 'MALE' },
      audioConfig: { audioEncoding: 'MP3' },
    };
  
    this.isSpeaking = true;// speech is in progress
  
    this.http.post(`https://texttospeech.googleapis.com/v1/text:synthesize?key=AIzaSyAQYRTZ6R3ZTDROhwWYCTUsm7EB9ZEIDwI`, requestBody)
      .subscribe((response: any) => {
        const audioContent = response.audioContent;
        const audio = new Audio('data:audio/mp3;base64,' + audioContent);
        this.currentAudio = audio;
  
        if (this.currentPlaybackPosition !== null) {
          audio.currentTime = this.currentPlaybackPosition;
          this.currentPlaybackPosition = null;
        }
  
        audio.play();
        audio.addEventListener('ended', () => {
          this.isSpeaking = false; // Reset the flag when speech ends
          this.openRiddle(markerInfo.label.id);
        });
      }, (error: any) => {
        console.error('Error synthesizing speech:', error);
        this.isSpeaking = false; // Reset the flag in case of error
      });
  }
  openRiddle(id: number) {
    this._riddleService.getRiddle(id).subscribe({
      next: (res) => {
        console.log(res);

        this.correctAnswer = res.correctAnswerId
        const dialogData = {
          text1: 'Brain Teaser',
          text2: res.question,
          button1: {
            label: res.answer1,
            onClick: () => {
              this.ansCheck(1);
            },
          },
          button2: {
            label: res.answer2,
            onClick: () => {
              this.ansCheck(2);

            },
          },
          button3: {
            label: res.answer3,
            onClick: () => {
              this.ansCheck(3);
            },
          },
        };

        this.dialog.open(RiddleDialogComponent, {
          data: dialogData,
          height: '500px',
          width: '350px',
        });

      },
      error: (err) => {
        console.log(err);

      }
    })

  }


  toggleSpeaking(markerInfo: any): void {
    if (this.currentAudio && !this.currentAudio.paused) {
      this.currentPlaybackPosition = this.currentAudio.currentTime;
      this.currentAudio.pause();
    } else if (this.currentAudio && this.currentAudio.paused) {
      this.currentAudio.play();
    } else {
      this.speakTextInfo(markerInfo);
    }
  }

  stopSpeaking(): void {
    if (this.currentAudio) {
      this.currentAudio.pause();
      this.currentPlaybackPosition = null;
      this.isSpeaking = false;
    }
  }

  ansCheck(ans: number): void {
    if (ans === this.correctAnswer) {
      if (typeof localStorage !== 'undefined') {
        const token: string | null = localStorage.getItem('ACCESS_TOKEN');

        if (token !== null) {
          this._userService.addPoint().subscribe({
            next: () => {
              console.log('Points added successfully');
              this.dialog.open(DialogComponent, {
                data: this.dialogData1,
                height: '500px',
                width: '350px',
              });
            },

            error: (error) => {
              console.error('🤦‍♀️🤦‍♀️🤦‍♀️Failed to add points:', error);
            }
          });
        } else {
          console.error('ACCESS_TOKEN is null');
        }
      }
    }
    else{
      this.dialog.open(DialogComponent, {
        data: this.dialogData2,
        height: '500px',
        width: '350px',
      });

    }
  }
  view_option(){

    if (this.focus)
    this.zoom=15;
    else
    this.zoom=20;
    this.focus=!this.focus

  }
}
