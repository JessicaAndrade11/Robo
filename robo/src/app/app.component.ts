import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HeadService } from './config/head.service';
import { LeftArmService } from './config/left-arm.service';
import { RightArmService } from './config/right-arm.service';
import { RoboService } from './config/robo.service';
import { Head } from './models/head.model';
import { Robo } from './models/robo.model';

interface HeadRotation {
  name: string;
  value: number;
}

interface Tilt {
  name: string;
  value: number;
}

interface ArmRotation {
  name: string;
  value: number;
}

interface Contraction {
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
  headTiltControl = new FormControl<Tilt | null>(null, Validators.required);
  rightArmRotationControl = new FormControl<ArmRotation | null>(null, Validators.required);
  rightArmContractionControl = new FormControl<Contraction | null>(null, Validators.required);
  leftArmRotationControl = new FormControl<ArmRotation | null>(null, Validators.required);
  leftArmContractionControl = new FormControl<Contraction | null>(null, Validators.required);
  selectFormControl = new FormControl('', Validators.required);

  headRotations: HeadRotation[] = [
    { name: 'Minus90', value: -90 },
    { name: 'Minus45', value: -45 },
    { name: 'Rest', value: 0 },
    { name: 'Plus45', value: 45 },
    { name: 'Plus90', value: 90 }
  ];

  headTilts: Tilt[] = [
    { name: 'Up', value: 10 },
    { name: 'Rest', value: 20 },
    { name: 'Down', value: 30 }
  ];

  contractions: Contraction[] = [
    { name: 'Rest', value: 0 },
    { name: 'SlightlyContracted', value: 10 },
    { name: 'Contracted', value: 20 },
    { name: 'StronglyContracted', value: 30 }
  ];

  armRotations: ArmRotation[] = [
    { name: 'Minus90', value: -90 },
    { name: 'Minus45', value: -45 },
    { name: 'Rest', value: 0 },
    { name: 'Plus45', value: 45 },
    { name: 'Plus90', value: 90 },
    { name: 'Plus135', value: 135 },
    { name: 'Plus180', value: 180 }
  ];

  constructor(
    private roboService: RoboService,
    private headService: HeadService,
    private rightArmService: RightArmService,
    private leftArmService: LeftArmService
  ) { }

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


  setHeadRotation() {
    this.errorMessage = '';
    var rotation = this.headRotationControl.value?.value as number;
    const data = this.robo.head;

    this.headService.updateRotation(data, rotation)
      .subscribe({
        next: (res) => {
          this.robo.head = res;
        },
        error: (e) => this.errorMessage = (e.error)
      });
  }

  setHeadTilt() {
    this.errorMessage = '';
    var tilt = this.headTiltControl.value?.value as number;
    const data = this.robo.head;

    this.headService.updateTilt(data, tilt)
      .subscribe({
        next: (res) => {
          this.robo.head = res;
        },
        error: (e) => this.errorMessage = (e.error)
      });
  }

  setRightArmWristRotation() {
    this.errorMessage = '';
    var rotation = this.rightArmRotationControl.value?.value as number;
    const data = this.robo.rightArm;

    this.rightArmService.updateWristRotation(data, rotation)
      .subscribe({
        next: (res) => {
          this.robo.rightArm = res;
        },
        error: (e) => this.errorMessage = (e.error)
      });
  }

  setRightArmElbowContraction() {
    this.errorMessage = '';
    var contraction = this.rightArmContractionControl.value?.value as number;
    const data = this.robo.rightArm;

    this.rightArmService.updateElbowContraction(data, contraction)
      .subscribe({
        next: (res) => {
          this.robo.rightArm = res;
        },
        error: (e) => this.errorMessage = (e.error)
      });
  }

  setLeftArmWristRotation() {
    this.errorMessage = '';
    var rotation = this.leftArmRotationControl.value?.value as number;
    const data = this.robo.leftArm;

    this.leftArmService.updateWristRotation(data, rotation)
      .subscribe({
        next: (res) => {
          this.robo.leftArm = res;
        },
        error: (e) => this.errorMessage = (e.error)
      });
  }

  setLeftArmElbowContraction() {
    this.errorMessage = '';
    var contraction = this.leftArmContractionControl.value?.value as number;
    const data = this.robo.leftArm;

    this.leftArmService.updateElbowContraction(data, contraction)
      .subscribe({
        next: (res) => {
          this.robo.leftArm = res;
        },
        error: (e) => this.errorMessage = (e.error)
      });
  }

}
