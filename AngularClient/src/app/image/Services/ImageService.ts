import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { ImageData } from "../image.component";


@Injectable()
export class ImageService {

  private baseUrl = "https://localhost:44398/api/Image";

  constructor(private http: HttpClient) { }

  GetFragments(imageData: ImageData) {
    let params = new HttpParams();
    params = params.append('rows', imageData.rows.toString());
    params = params.append('columns', imageData.columns.toString());
    return this.http.post(this.baseUrl, imageData.image, {params: params});
  }
}