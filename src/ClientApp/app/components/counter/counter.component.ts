import { Component } from '@angular/core';

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html'
})
export class CounterComponent {
    currentCount = 0;

    incrementCounter() {
        ++ this.currentCount;
    }

    //public incrementCounter(amount: number = 1) {
    //    this.currentCount += amount;
    //}

    //public decrementCounter(amount: number = 1) {
    //    this.currentCount -= amount;
    //}
}