import { Component } from '@angular/core';
import { ImageService } from './Services/ImageService';

export class ImageData{
  constructor(public imgWidth: number, public imgHeight: number, public rows: number,
             public columns: number, public image: FormData){ }
}

export class Fragment {
  constructor(public url: string, public width: number, public height: number) {}
}

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css'],
  providers: [ImageService]
})
export class ImageComponent {
  imageData: ImageData = new ImageData(0, 0, 1, 1, new FormData());
  url = "";
  fragments: Fragment[] = [];
  imageIsLoaded: boolean = false;
  responseFromServer: boolean = false;


  constructor(private imageService: ImageService) {}


  public uploadFile = (files: File[]) => {
    if (files.length === 0) { 
      this.url = "";
      this.imageIsLoaded = false;
      return; 
    }
    this.responseFromServer = false;
    this.imageIsLoaded = true;
    this.imageData.image = new FormData();
    let fileToUpload = <File>files[0];
    let reader = new FileReader();
    reader.readAsDataURL(fileToUpload);
    reader.onload = (event: any) => { 
      this.url = event.target.result;
      var img = new Image();
      img.src = event.target.result;
      img.onload = () => {
        this.imageData.imgWidth = img.width;
        this.imageData.imgHeight = img.height;
      };
    }
    this.imageData.image.append('file', fileToUpload, fileToUpload.name);
  }


  public SendImageData = () => {
    if (this.imageData.rows <= 0 || this.imageData.columns <= 0) {
      alert("Rows and Columns must be > 0");
      return;
    }
    if (this.imageIsLoaded === false) {
      alert("Image must be uploaded");
      return;
    }
    this.imageService.GetFragments(this.imageData)
        .subscribe((result: any) => {
          this.fragments = [];
          for (var res of result) {
            this.fragments.push(new Fragment("data:image/jpeg;base64," + res.FragmentData, res.Width, res.Height));
          }
          this.responseFromServer = true;
        });
  }
}
