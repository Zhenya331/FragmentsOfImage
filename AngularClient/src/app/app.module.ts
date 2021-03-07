import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ImageComponent } from './image/image.component';
import { HttpClientModule } from '@angular/common/http';
import { FragmentsComponent } from './image/fragments/fragments.component';

@NgModule({
  declarations: [AppComponent, ImageComponent, FragmentsComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
