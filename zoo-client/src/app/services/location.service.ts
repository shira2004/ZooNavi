import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor() { }

  watchPosition(markerPositions: any[], thresholdDistance: number): Observable<{ lng: number, lat: number }> {
    return new Observable((observer: Observer<{ lng: number, lat: number }>) => {
      const watchId = navigator.geolocation.watchPosition(
        (position) => {
          const userPosition = { lng: position.coords.longitude, lat: position.coords.latitude };
          observer.next(userPosition);
          markerPositions.forEach(marker => {
            const markerPosition = marker.position;

            // Calculate distance between user and marker
            const distance = google.maps.geometry.spherical.computeDistanceBetween(
              new google.maps.LatLng(userPosition.lat, userPosition.lng),
              new google.maps.LatLng(markerPosition.lat, markerPosition.lng)
            );

            if (distance <= thresholdDistance) {
              // to add trigger to text
              console.log('User is close to marker:', marker);
            }
          });
        },
        (error) => {
          observer.error(error);
        }
      );
      
      return {
        unsubscribe() {
          navigator.geolocation.clearWatch(watchId);
        }
      };
    });
  }
}