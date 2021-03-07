import { Component, Input, OnInit } from '@angular/core';
import { Fragment } from '../image.component';

@Component({
  selector: 'app-fragments',
  templateUrl: './fragments.component.html',
  styleUrls: ['./fragments.component.css']
})
export class FragmentsComponent implements OnInit {
  @Input() numOfFragments: number;
  @Input() fragments: Fragment[];

  constructor() { }

  ngOnInit(): void {
  }
}
