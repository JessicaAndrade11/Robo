import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HeadService } from './config/head.service';
import { RoboService } from './config/robo.service';
import { Head } from './models/head.model';
import { Robo } from './models/robo.model';

interface HeadRotation {
  name: string;
  value: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'robo';
  robo = new Robo;
  errorMessage = '';
  panelOpenState = false;
  headRotationControl = new FormControl<HeadRotation | null>(null, Validators.required);
  selectFormControl = new FormControl('', Validators.required);

  headRotations: HeadRotation[] = [
    { name: 'Minus90', value: -90 },
    { name: 'Minus45', value: -45 },
    { name: 'Rest', value: 0 },
    { name: 'Plus45', value: 45 },
    { name: 'Plus90', value: 90 },
  ];

  constructor(private roboService: RoboService, private headService: HeadService) { }

  ngOnInit(): void {
    this.roboService.create()
      .subscribe({
        next: (res) => {
          this.robo = res;
          console.log(this.robo);
        },
        error: (e) => console.error(e)
      });
  }


  setRotation() {
    this.errorMessage = '';
    var rotation = this.headRotationControl.value?.value as number;
    console.log(this.robo.head);
    const data = this.robo.head;
 
    this.headService.updateRotation(data, rotation)
      .subscribe({
        next: (res) => {
          this.robo.head = res;
        },
        error: (e) => this.errorMessage = (e.error)
      });
  }

}
