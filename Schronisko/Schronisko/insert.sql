
--USERS
--WSZYSTKIE HASLA TO: haslo123
insert into Users (login, name, password, role, email) values ('worker', 'worker', '1a7fcdd5a9fd433523268883cfded9d0', 'worker', 'worker@cos.com');
insert into Users ( login, name, password, role, email) values ( 'user', 'user', '1a7fcdd5a9fd433523268883cfded9d0', 'user', 'user@cos.com');
insert into Users ( login, name, password, role, email) values ( 'admin', 'admin', '1a7fcdd5a9fd433523268883cfded9d0', 'admin','admin@cos.com');
insert into Users ( login, name, password, role, email) values ( 'manager', 'manager', '1a7fcdd5a9fd433523268883cfded9d0', 'manager','manager@cos.com');
insert into Users ( login, name, password, role, email) values ( 'user1', 'user1', '1a7fcdd5a9fd433523268883cfded9d0', 'user1', 'user1@cos.com');
insert into Users ( login, name, password, role, email) values ( 'user2', 'user2', '1a7fcdd5a9fd433523268883cfded9d0', 'user2', 'user2@cos.com');
insert into Users ( login, name, password, role, email) values ( 'user3', 'user3', '1a7fcdd5a9fd433523268883cfded9d0', 'user3', 'user3@cos.com');
insert into Users ( login, name, password, role, email) values ( 'user4', 'user4', '1a7fcdd5a9fd433523268883cfded9d0', 'user4', 'user4@cos.com');
insert into Users ( login, name, password, role, email) values ( 'user5', 'user5', '1a7fcdd5a9fd433523268883cfded9d0', 'user5', 'user5@cos.com');
insert into Users ( login, name, password, role, email) values ( 'admin1', 'admin1', '1a7fcdd5a9fd433523268883cfded9d0', 'admin','admin@cos.com');
insert into Users ( login, name, password, role, email) values ( 'manager1', 'manager1', '1a7fcdd5a9fd433523268883cfded9d0', 'manager','admin@cos.com');
insert into Users ( login, name, password, role, email) values ( 'worker1', 'worker1', '1a7fcdd5a9fd433523268883cfded9d0', 'worker', 'worker1@cos.com');
insert into Users ( login, name, password, role, email) values ( 'worker2', 'worker2', '1a7fcdd5a9fd433523268883cfded9d0', 'worker', 'worker2@cos.com');
insert into Users ( login, name, password, role, email) values ( 'worker3', 'worker3', '1a7fcdd5a9fd433523268883cfded9d0', 'worker', 'worker3@cos.com');
insert into Users ( login, name, password, role, email) values ( 'worker4', 'worker4', '1a7fcdd5a9fd433523268883cfded9d0', 'worker', 'worker4@cos.com');

--RACES
insert into Races ( name, description, origin, size, for_child, for_animal) values ('Husky', 'Majestatyczna rasa', 'Północ', 'duże', 'bywa agresywny', 'bywa agresywny' );
insert into Races ( name, description, origin, size, for_child, for_animal) values ('Pudel miniaturowy', 'Delikatny psychicznie. Błyskawicznie się uczy. Miniaturowy jest bardziej ruchliwy niż duży czy średni.', 'Pies myśliwski', 'Średnie', 'wesoły, czuły i nieagresywny', 'Lubią się bawić z pobratymcami' );
INSERT INTO Races ( name, description) VALUES ('Mieszaniec', 'Bywają bardzo różne');
INSERT INTO Races ( name, description, origin, size, for_child, for_animal) VALUES ('Pointer ', 'pies o niezwykle szlachetnej, eleganckiej sylwetce, obdarzony miłym charakterem', 'Pies myśliwski', 'duże', 'czuły i delikatny wobec dzieci', 'Chętnie bawi się z innymi psami' );
INSERT INTO Races ( name, description, origin, size, for_child, for_animal) VALUES ('Chart', 'dobrze umięśniony pies o smukłej sylwetce, długich nogach i szlachetnej, wąskiej głowie.', 'Pies myśliwski', 'duże', 'bywa agresywny', 'bywa agresywny' );
INSERT INTO Races ( name, description, size, for_child, for_animal) VALUES ('Doberman ', 'lekkiej, atletycznej budowy pies pokryty gęstą, lśniącą, krótką sierścią.', 'duże', 'może być niebezpieczny', 'bywa agresywny' );
INSERT INTO Races ( name, description, origin, size, for_child, for_animal) VALUES ('Dalmatyńczyk ', 'pies o bardzo charakterystycznym umaszczeniu: białym w czarne lub (rzadziej) brązowe cętki. Ruchliwy, niezbyt uległy. ', 'USA', 'duże', 'często traktowane jak maskotki dla dzieci', ' Zwykle jest też tolerancyjny wobec obcych psów' );
INSERT INTO Races ( name, description, origin, size, for_child, for_animal) VALUES ('Wyżeł ', 'jest jak arystokrata starej daty – dystyngowany, życzliwy i ceniący życie rodzinne.', 'Europa', 'duże, smukłe', 'akceptuje towarzystwo dzieci', 'świetny kompan' );
INSERT INTO Races ( name, description, origin, size, for_child, for_animal) VALUES ('Labrador', 'to rasa psów żywiołowych, skorych do zabawy, także z innymi psami', 'Kanada', 'duże', 'przyjacielski', 'przyjacielski' );

--DOGS

INSERT INTO dbo.Dogs ( name, year_of_birth, description, id_race) VALUES ( 'Oczko', 2007, 'Dziki, często ucieka', 5);
INSERT INTO dbo.Dogs ( name, year_of_birth, description, id_race) VALUES ( 'Fąfel', 2006, 'Chciałby mieć warkocze', 6);
INSERT INTO dbo.Dogs ( name, description, id_race) VALUES ( 'Piszczel', 'Cichy, lojalny', 7);
INSERT INTO dbo.Dogs ( name,  description, id_race) VALUES ( 'Paprotka',  'Bardzo towarzyska', 7);
INSERT INTO dbo.Dogs ( name, description, id_race) VALUES ( 'Figa', 'Dzika, inteligentna', 9);
INSERT INTO dbo.Dogs ( name,  description, id_race) VALUES ( 'Gacek', 'Energiczny', 1);
INSERT INTO dbo.Dogs ( name, year_of_birth, description, id_race) VALUES ( 'Szpak', 2014, 'towarzyski', 2);
INSERT INTO dbo.Dogs ( name, year_of_birth, description, id_race) VALUES ( 'Bąbel', 20016, 'Dziki ale miły', 7);

--










--