import { Event } from '../../Models/Event.model';
import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/services/event.service';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss'],
})
export class EventListComponent implements OnInit {
  eventArray: Array<Event> = [];
  EventList = new Event();
  data: any;
  name: string = '';
  // popupforms: FormGroup;
  constructor(private service: EventService, private route: ActivatedRoute) {}
  ngOnInit(): void {
    // this.getdata();
    this.eventArray = this.route.snapshot.data['message'];
    console.log(this.eventArray);
  }

  getdata() {
    this.service.getdata().subscribe((res) => {
      this.eventArray = res;
      console.log(res);
    });
  }
  id = '';
  obj: any;
  Edit(eventId: any) {
    this.id = eventId;
    this.obj = this.eventArray.values;
  }

  editEvent(EventList: any) {
    console.log(EventList.id);

    this.service.SaveChanges(EventList.id, EventList).subscribe((res) => {
      console.log(res);

      this.getdata();
    });
  }
  saveSomeThing(id: any) {
    this.id = id;
  }
  Delete() {
    this.service.Delete(this.id).subscribe((data) => {
      this.getdata();
    });
  }

  edit(EventList: any) {
    console.log(EventList);
    this.EventList.name = EventList.name;
    this.EventList.place = EventList.place;
    this.EventList.time = EventList.time;
    this.EventList.details = EventList.details;
    this.EventList.duration = EventList.duration;
    this.EventList.comments = EventList.comments;
    this.EventList.id = EventList.id;
  }

  page: any = 1;
  size: any = 1;
  psize: any = [1, 3, 5, 10];
  onPageChange(event: any) {
    this.page = event;
    this.getdata();
  }
  onPageSizeChange(event: any) {
    this.size = event.target.value;
    this.page = 1;
    this.getdata();
  }
  getByPage(pageNo: any, pageSize: any) {
    this.service.GetPerging(pageNo, pageSize).subscribe((res) => {
      this.eventArray = res;
    });
  }
  Search(name: string) {
    if (name.length > 0) {
      console.log(name);

      this.service.Search(name).subscribe((res) => {
        this.eventArray = res;
        console.log(res);
      });
    } else {
      console.log(name);

      this.getByPage(1, 3);
    }
  }
}
