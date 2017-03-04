using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using IEvangelist.Angular.Models;

namespace IEvangelist.Angular.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return new Character[] 
            {
                new Character
                {
                    Name = "Hulk",
                    RealName = "Bruce Banner",
                    Description = "Caught in a gamma bomb explosion while trying to save the life of a teenager, Dr. Bruce Banner was transformed into the incredibly powerful creature called the Hulk. An all too often misunderstood hero, the angrier the Hulk gets, the stronger the Hulk gets.",
                    Powers = "The Hulk possesses an incredible level of superhuman physical ability. His capacity for physical strength is potentially limitless due to the fact that the Hulk's strength increases proportionally with his level of great emotional stress, anger in particular. The Hulk uses his superhumanly strong leg muscles to leap great distances. The Hulk has been known to cover hundreds of miles in a single bound and once leaped almost into orbit around the Earth. The Hulk can also use his superhumanly leg muscles to run at super speeds, although his legs have limitless strength he does not have limitless speed and once he reaches a certain speed his legs become too strong and destroy the ground giving him no friction to run on, therefore he jumps to travel. The Hulk can slam his hands together creating a shock wave, this shock wave can deafen people, send objects flying and extinguish fires. His thunderclap has been compared to hurricanes and sonic booms. The Hulk has shown a high resistance to physical damage nearly regardless of the cause, and has also shown resistance to extreme temperatures, mind control, nuclear explosions, poisons, and all diseases. In addition to the regeneration of limbs, vital organs, and damaged or destroyed areas of tissue at an amazing rate. The Hulk also has superhuman endurance.The Hulk's body also has a gland that makes an \"oxygenated per fluorocarbon emulsion\", which creates pressure in the Hulk's lungs and effectively lets him breathe underwater and move quickly between varying depths without concerns about decompression or nitrogen narcosis.",
                    Abilities = "Dr. Bruce Banner is a genius in nuclear physics, possessing a mind so brilliant that it cannot be measured on any known intelligence test. When Banner is the Hulk, Banner's consciousness is buried within the Hulk's, and can influence the Hulk's behavior only to a very limited extent.",
                    Height = "5' 9½\" (Banner); 6'6\" (gray Hulk); 7' – 8' (green/savageHulk); 7'6\" (green/Professor Hulk)",
                    Weight = "128 lbs. (Banner); 900 lbs. (gray Hulk); 1,040 – 1,400 lbs.(green/savage Hulk); 1,150 lbs. (green/Professor Hulk)"
                },
                new Character
                {
                    Name = "Captain America",
                    RealName = "Steven \"Steve\" Rogers",
                    Description = "Vowing to serve his country any way he could, young Steve Rogers took the super soldier serum to become America's one-man army. Fighting for the red, white and blue for over 60 years, Captain America is the living, breathing symbol of freedom and liberty.",
                    Powers = "Captain America represented the pinnacle of human physical perfection. He experienced a time when he was augmented to superhuman levels, but generally performed just below superhuman levels for most of his career. Captain America had a very high intelligence as well as agility, strength, speed, endurance, and reaction time superior to any Olympic athlete who ever competed. The Super-Soldier formula that he had metabolized had enhanced all of his bodily functions to the peak of human efficiency. Most notably, his body eliminates the excessive build-up of fatigue-producing poisons in his muscles, granting him phenomenal endurance.",
                    Abilities = "Captain America had mastered the martial arts of American-style boxing and judo, and had combined these disciplines with his own unique hand-to-hand style of combat. He had also shown skill and knowledge of a number of other martial arts. He engaged in a daily regimen of rigorous exercise (including aerobics, weight lifting, gymnastics, and simulated combat) to keep himself in peak condition. Captain America was one of the finest human combatants Earth had ever known.",
                    Height = "6' 2\"",
                    Weight = "220 lbs."
                },
                new Character
                {
                    Name = "Iron Man",
                    RealName = "Tony Stark",
                    Description = "Wounded, captured and forced to build a weapon by his enemies, billionaire industrialist Tony Stark instead created an advanced suit of armor to save his life and escape captivity. Now with a new outlook on life, Tony uses his money and intelligence to make the world a safer, better place as Iron Man.",
                    Powers = "None; Tony's body had been enhanced by the modified techno-organic virus, Extremis, but it is currently inaccessible and inoperable.",
                    Abilities = "Tony has a genius level intellect that allows him to invent a wide range of sophisticated devices, specializing in advanced weapons and armor. He possesses a keen business mind.",
                    Height = "6'1\"; (in armor) 6'6\"",
                    Weight = "225 lbs.; (in armor) 425 lbs."
                },
                new Character
                {
                    Name = "Falcon",
                    RealName = "Samuel Thomas \"Sam\" Wilson",
                    Description = "With a mental connection to all birds and a suit that gives him wings to fly, The Falcon has been both the partner to Captain America and an Avenger himself. Whether as a super hero or in his secret identity of social worker Sam Wilson, The Falcon dedicates his life to standing up for others.",
                    Powers = "Originally possessed the ability to telepathically communicate with his pet falcon Redwing, but that ability has grown into the ability to telepathically communicate with any birds within an unknown radius. Through this telepathic link he is also able to receive mental images of what the birds see.",
                    Abilities = "Excellent trainer of birds, and has been highly trained in gymnastics and hand-to-hand combat by Captain America (Steve Rogers), Captain America.",
                    Height = "6'2\"",
                    Weight = "240 lbs."
                },
                new Character
                {
                    Name = "Star-Lord",
                    RealName = "Peter Jason Quill",
                    Description = "Refusing to miss his opportunity, Peter Jason Quill stole a scoutship from Cape Canaveral, returned to Eve, and shot his way to the appointed spot, where his old rival Harrelson, NASA's choice to be Star-Lord, was awaiting selection, where Quill was transported away in his stead, and transformed into Star-Lord",
                    Powers = "Star-Lord wore a costume that enabled him to survive in space. It is possible that the costume has actually altered his physical structure, as he does not need to wear any helmet, or any form of life support to survive the nearly absolute zero, airless vacuum. He can fly through air or in space, presumably another attribute of his costume. He possesses enhanced healing and uses personal energy shields. In the event that he were injured beyond his own ability to recover, Ship could administer emergency medical or surgical care.Star-Lord later received a number of cybernetic implants, including his left eye, which allows him to see all energy spectra, as well as a memory chip in his brain, which gives 100% recall.",
                    Abilities = "In addition, Star-Lord is highly athletic, a skilled marksman and swordsman, and proficient at hand-to-hand combat. After overcoming his lifetime of hatred, Star-Lord took a vow to never take another life unless absolutely necessary. His greatest asset is his partner and would-be lover, Ship.",
                    Height = "6'2\"",
                    Weight = "175 lbs."
                }
            };
        }
        
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}