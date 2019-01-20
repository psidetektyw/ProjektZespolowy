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

        public static EventsModel ToEventsModelWithID(this Events given)
        {
            EventsModel e = new EventsModel();
            e.id = given.id;
            e.approved = given.approved;
            e.date = given.date;
            e.description = given.description;
            e.id_dog = given.id_dog;
            e.id_user = given.id_user;
            e.time = given.time;
            e.time_end = given.time_end;
            return e;
        }

        public static Events ToEventsWithoutID(this EventsModel given)
        {
            Events e = new Events();
            e.approved = given.approved;
            e.date = given.date;
            e.description = given.description;
            e.id_dog = given.id_dog;
            e.id_user = given.id_user;
            e.time = given.time;
            e.time_end = given.time_end;
            return e;
        }

        public static Events ToEventsWithID(this EventsModel given)
        {
            Events e = new Events();
            e.id = given.id;
            e.approved = given.approved;
            e.date = given.date;
            e.description = given.description;
            e.id_dog = given.id_dog;
            e.id_user = given.id_user;
            e.time = given.time;
            e.time_end = given.time_end;
            return e;
        }

        public static EventsModel ToEventsModelWithoutID(this Events given)
        {
            EventsModel e = new EventsModel();
            e.approved = given.approved;
            e.date = given.date;
            e.description = given.description;
            e.id_dog = given.id_dog;
            e.id_user = given.id_user;
            e.time = given.time;
            e.time_end = given.time_end;
            return e;
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
            if(dogs.id_race!=null)
            d.id_race = (int)dogs.id_race;
            return d;
        }

        public static Dogs ToDogsWithoutID(this DogsModel dogs)
        {
            Dogs d = new Dogs();
            d.name = dogs.name;
            d.year_of_birth = dogs.year_of_birth;
            d.description = dogs.description;
            d.photo_path = dogs.photo_path;
            if (dogs.id_race != null)
                d.id_race = (int)dogs.id_race;
            return d;
        }

        public static Dogs DogsSameValuesWithoutID(Dogs d, DogsModel dogs)
        {
            d.name = dogs.name;
            d.year_of_birth = dogs.year_of_birth;
            d.description = dogs.description;
            d.photo_path = dogs.photo_path;
            d.Races = dogs.races;
            if (dogs.id_race != null)
                d.id_race = (int)dogs.id_race;
            return d;
        }
    }
}