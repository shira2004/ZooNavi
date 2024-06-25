export function handleFileSelected(event: any, callback: (base64Image: string) => void): void {
    const selectedImage = event.target.files[0];
  
    if (selectedImage) {
      const reader = new FileReader();
  
      reader.onload = (e) => {
        const base64Image = e.target?.result as string;
        callback(base64Image);
      };
  
      reader.readAsDataURL(selectedImage);
    }
  }
  