import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent implements OnInit {
    forecasts: WeatherForecast[] = [];
    isFetching = false;

    get count(): number {
        return this.forecasts.length;
    }

    constructor(private http: Http) { }

    ngOnInit() {
        this.attemptGet();
    }

    attemptGet() {
        this.isFetching = true;
        this.http
            .get('/api/SampleData/WeatherForecasts')
            .retry(10) // Automatically retry 10 times...
            .subscribe(result => {
                this.forecasts = result.json() as WeatherForecast[];
                this.isFetching = false;
            });
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}