CREATE TABLE portate (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE piatti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT,prezzo REAL, id_portate INTEGER, FOREIGN KEY (id_portate) REFERENCES portate(id));

INSERT INTO portate (nome) VALUES ('antipasti');
INSERT INTO portate (nome) VALUES ('primi');
INSERT INTO portate (nome) VALUES ('secondi');
INSERT INTO portate (nome) VALUES ('vini');
INSERT INTO portate (nome) VALUES ('dolci');

INSERT INTO piatti (id_portate, nome, prezzo) VALUES (1,'Quadro d’autore con caviale', 55);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (1,'Gran crudo di mare: ostriche crostacei tartare e fantasia di pesce bianco',65);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (1,'Proposta di tre piccole portate calde',50);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (1,'Sandwich di triglia e scarola su gazpacho di pomodoro verde',35);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (1,'La Caprese secondo lo Chef',25);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (1,'Flan di verdure con leggera fonduta di parmigiano e tartufo di stagione',40);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (1,'Torcione naturale di fegato d’oca confettura di zucca al peperoncino',40);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (2,'Bavette sul pesce Pasta risottata con scampetti totanini seppiette e gamberetti biondi',35);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (2,'Fusillone al topinambur scampi e dressing alla birra',40);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (2,'Scucuzzùn mantecato ai ceci di spello calamaro scottato alla salvia e profumo di agrumi',35);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (2,'Ravioli all’ortica tartare di gambero rosso e il suo ristretto',40);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (2,'Bottoni farciti di radicchio fonduta di Scoppolato di Pedona e perle di bitter',35);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (2,'Vellutata di farro della Garfagnana e fagioli rossi di Sorana',25);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (2,'Tagliolini al filetto di pomodoro e basilico di Prà',25);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (3,'Filetto di rombo al forno scaloppa di fegato d’oca tartufo nero e riduzione al Porto',40);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (3,'Natura di calamaretti di sabbia in forno al profumo di Vermentino con millefoglie di verdure',45);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (3,'Astice (o Aragosta)in crosta speziata daikon cremoso di carote e scaglie di aceto balsamico',65);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (3,'Filetto di Fassona piemontese alla Rossini',55);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (3,'Soffice di vitello brasato mosto cotto e  grano saraceno soffiato',35);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (3,'Petto d’anatra cotto a bassa temperatura peschiere saltate riduzione al mirto e pavé di patate',40);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (4,'Passito di Pantelleria Ben Ryé ‘21 Donna Fugata',15);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (4,'Muffato della Sala ‘19 Antinori',20);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (4,'Moscato d’Asti “Bricco Quaglia” ‘22 La Spinetta',10);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (4,'Sauternes ‘14 Raymod-Lafon',20);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (4,'Gewurtztraminer Terminus ’22 Dramen',30);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (5,'Tiramisù glassa al caffè e biscotto al cioccolato',15);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (5,'La pastiera 2024',15);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (5,'Apple Pie: tortino di pasta briseé alla mela e gelato alla crema',15);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (5,'Semifreddo al passion fruit e spuma di Champagne',15);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (5,'I nostri sorbetti',10);
INSERT INTO piatti (id_portate, nome, prezzo) VALUES (5,'Selezione di formaggi italiani e esteri',20);

CREATE TABLE tavoli (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE turni (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE ordinazioni (id INTEGER PRIMARY KEY AUTOINCREMENT, id_tavolo INTEGER, id_turno INTEGER, id_piatto INTEGER, quantita REAL, stato BOOLEAN, FOREIGN KEY (id_tavolo) REFERENCES tavoli(id), FOREIGN KEY (id_piatto) REFERENCES piatti(id), FOREIGN KEY (id_turno) REFERENCES turni(id));

INSERT INTO tavoli (nome) VALUES ('1A');
INSERT INTO tavoli (nome) VALUES ('2A');
INSERT INTO tavoli (nome) VALUES ('3B');
INSERT INTO tavoli (nome) VALUES ('4Terrazzo');
INSERT INTO tavoli (nome) VALUES ('5Veranda');

INSERT INTO turni (nome) VALUES ('12.00-13.00');
INSERT INTO turni (nome) VALUES ('13.00-14.00');
INSERT INTO turni (nome) VALUES ('14.00-15.00');
INSERT INTO turni (nome) VALUES ('19.00-20.30');
INSERT INTO turni (nome) VALUES ('20.30-22.00');
INSERT INTO turni (nome) VALUES ('22.00-23.00');

INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (1, 1, 30, 5, 0);
INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (2, 1, 21,6, 1);
INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (1, 2, 3,5,1);
INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (1, 3, 3,3,1);
INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (1, 4, 2,5,1);
INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (1, 5, 1,4,1);
INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (1, 6, 11,5, 1);
INSERT INTO ordinazioni (id_tavolo, id_turno, id_piatto, quantita, stato) VALUES (1, 5, 22,5, 1);