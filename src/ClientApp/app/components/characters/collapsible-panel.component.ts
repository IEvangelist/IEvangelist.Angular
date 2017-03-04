import { Component, Input } from '@angular/core'

@Component({
    selector: 'collapsible-panel',
    templateUrl: './collapsible-panel.component.html',
    styleUrls: ['./collapsible-panel.component.css']
})
export class CollapsiblePanelComponent {
    @Input() header: string;
    
    private headerId: string;
    private buttonId: string;
    private static instances = 0;

    constructor() {
        const count = ++ CollapsiblePanelComponent.instances;
        this.headerId = `header${count}`;
        this.buttonId = `button${count}`;
    }
}