import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Weather } from './services/weather';
import { CommonModule, JsonPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JsonPipe],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  title = 'PersonalFinanceUI'
  // weatherData : any[] = []
  weatherData = signal<any[]>([])
 
  
  

  constructor(private weatherService : Weather ){}

  async ngOnInit(): Promise<void> {
    this.weatherService.getWeather().subscribe(
      {
        next: (data) => {
          this.weatherData.set(data)
          // this.weatherData = data
          console.log('weather retreived successfully:', this.weatherData)
        },
        error: (err) => {
          console.error('error fetching weater data:', err)
        }
      }
    )
    
  }
}
