import { Component, OnInit } from '@angular/core'
import { Http } from '@angular/http';
import { CharacterAssetResolver } from './character-asset-resolver';
import { CollapsiblePanelComponent } from './collapsible-panel.component';

@Component({
    selector: 'character-editor',
    templateUrl: './character-editor.component.html',
    styleUrls: ['./character-editor.component.css']
})
export class CharacterEditorComponent implements OnInit {
    characters: Character[];
    character: Character;
    imageSource: string;

    constructor(private http: Http) { }

    ngOnInit() {
        this.http
            .get('api/characters')
            .subscribe(response =>
                this.onCharactersReceived(response.json() as Character[])
            );
    }   

    onCharactersReceived(characters: Character[]) {
        if (characters && characters.length) {
            // Mutable operation
            characters.sort((left, right): number =>
                left.name < right.name ? -1 : left.name > right.name ? 1 : 0
            );
            this.characters = characters;
            this.character = characters[0];
            this.onChange();
        }
    }

    onChange() {
        this.imageSource = CharacterAssetResolver.resolve(this.character.name);
    }
}

interface Character {
    id: string;
    name: string;
    realName: string;
    height: string;
    weight: string;
    description: string;
    powers: string;
    abilities: string;
}