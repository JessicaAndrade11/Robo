import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSelectModule } from "@angular/material/select";
import { HeadService } from './config/head.service';
import { RoboService } from './config/robo.service';
import { RightArmService } from './config/right-arm.service';
import { LeftArmService } from './config/left-arm.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatExpansionModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    HeadService,
    RoboService,
    RightArmService,
    LeftArmService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
