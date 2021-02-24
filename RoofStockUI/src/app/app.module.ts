import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './components/shared/shared.module';
import { HomeModule } from './components/home/home.module';
import { DetailsModule } from './components/details/details.module';
import { NotFoundModule } from './components/not-found/not-found.module';
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    HomeModule,
    HttpClientModule,
    DetailsModule,
    NotFoundModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
