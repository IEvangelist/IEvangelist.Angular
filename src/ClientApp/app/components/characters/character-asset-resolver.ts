export class CharacterAssetResolver {
    static resolve(name: string): any {
        switch (name) {
            case "Hulk":
                return require("./assets/hulk.png");
            case "Iron Man":
                return require("./assets/iron-man.png");
            case "Falcon":
                return require("./assets/falcon.png");
            case "Star-Lord":
                return require("./assets/star-lord.png");
            case "Captain America":
                return require("./assets/captain-america.png");
        }

        return "";
    }
}