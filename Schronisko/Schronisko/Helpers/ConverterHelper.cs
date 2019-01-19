using Schronisko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schronisko.Helpers
{
    public static class ConverterHelper
    {

        public static RacesModel ToRacesModelWithID(this Races races)
        {
            RacesModel r = new RacesModel();
            r.id = races.id;
            r.name = races.name;
            r.description = races.description;
            
            return r;
        }

        public static RacesModel ToRacesModelWithoutID(Races races)
        {
            RacesModel r = new RacesModel();
            r.name = races.name;
            r.description = races.description;

            return r;
        }

        public static Races ToRacesWithID(this RacesModel races)
        {
            Races r = new Races();
            r.id = races.id;
            r.name = races.name;
            r.description = races.description;

            return r;
        }

        public static Races ToRacesWithoutID(this RacesModel races)
        {
            Races r = new Races();
            r.name = races.name;
            r.description = races.description;

            return r;
        }


        public static Races RacesSameValuesWithoutID(Races r,RacesModel races)
        {
            r.name = races.name;
            r.description = races.description;

            return r;
        }



        public static DogsModel ToDogsModelWithID(this Dogs dogs)
        {
            DogsModel d = new DogsModel();
            d.id = dogs.id;
            d.name = dogs.name;
            d.year_of_birth = dogs.year_of_birth;
            d.description = dogs.description;
            d.photo_path = dogs.photo_path;
            d.id_race = dogs.id_race;
            return d;
        }


        public static DogsModel ToDogsModelWithoutID(this Dogs dogs)
        {
            DogsModel d = new DogsModel();
            d.name = dogs.name;
            d.year_of_birth = dogs.year_of_birth;
            d.description = dogs.description;
            d.photo_path = dogs.photo_path;
            d.id_race = dogs.id_race;
            return d;
        }



        public static Dogs ToDogsWithID(this DogsModel dogs)
        {
            Dogs d = new Dogs();
            d.id = dogs.id;
            d.name = dogs.name;
            d.year_of_birth = dogs.year_of_birth;
            d.description = dogs.description;
            d.photo_path = dogs.photo_path;
            d.id_race = dogs.id_race;
            return d;
        }

        public static Dogs ToDogsWithoutID(this DogsModel dogs)
        {
            Dogs d = new Dogs();
            d.name = dogs.name;
            d.year_of_birth = dogs.year_of_birth;
            d.description = dogs.description;
            d.photo_path = dogs.photo_path;
            d.id_race = dogs.id_race;
            return d;
        }

        public static Dogs DogsSameValuesWithoutID(Dogs d, DogsModel dogs)
        {
            d.name = dogs.name;
            d.year_of_birth = dogs.year_of_birth;
            d.description = dogs.description;
            d.photo_path = dogs.photo_path;
            d.Races = dogs.races;
            d.id_race = dogs.id_race;
            return d;
        }
    }
}