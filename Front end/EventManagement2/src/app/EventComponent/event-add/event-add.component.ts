import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-event-add',
  templateUrl: './event-add.component.html',
  styleUrls: ['./event-add.component.scss'],
})
export class EventAddComponent implements OnInit {
  forms: FormGroup;
  getData: any;
  constructor(private service: EventService) {
    this.forms = new FormGroup({
      name: new FormControl(),
      place: new FormControl(),
      time: new FormControl(),
      // EventStartTime: new FormControl(),
      details: new FormControl(),
      duration: new FormControl(),
      comments: new FormControl(),
    });
  }
  ngOnInit(): void {}
  postdata() {}
  submit() {
    this.service.postdata(this.forms.value).subscribe((res: any) => {
      this.forms.reset();
      console.log(res);
    });
  }
}
