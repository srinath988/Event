import { ContactService } from '../../services/contact.service';
import { Component } from '@angular/core';
import { FormsModule, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss'],
})
export class ContactComponent {
  ContactService: any;
  contact: FormGroup;
  constructor(private service: ContactService) {
    this.contact = new FormGroup({
      userName: new FormControl(),
      userEmail: new FormControl(),
      phone: new FormControl(),
      message: new FormControl(),
    });
  }
  save() {
    console.log(this.contact.value);
    this.service.postdata(this.contact.value).subscribe((res: any) => {
      this.contact.reset();
      console.log(res);
    });
  }
}
