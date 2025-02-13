import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CDBComponent } from './cdb/cdb.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CDBComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'b3';
}
