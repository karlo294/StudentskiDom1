/*
SQLyog Community v8.61 
MySQL - 5.5.5-10.4.18-MariaDB : Database - studentskidom2021
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`studentskidom2021` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `studentskidom2021`;

/*Table structure for table `korisnici` */

DROP TABLE IF EXISTS `korisnici`;

CREATE TABLE `korisnici` (
  `IdKorisnik` int(11) NOT NULL AUTO_INCREMENT,
  `oibKorisnik` varchar(11) NOT NULL,
  `imeKorisnik` varchar(120) NOT NULL,
  `prezimeKorisnik` varchar(120) NOT NULL,
  `emailKorisnik` varchar(240) NOT NULL,
  `mobKorisnik` varchar(135) DEFAULT NULL,
  `drzavaK` varchar(120) DEFAULT NULL,
  `godStudijaST` int(11) DEFAULT NULL,
  `statusStudenta` bit(1) DEFAULT NULL,
  `lozinka` text NOT NULL,
  `indikatorSA` bit(1) NOT NULL,
  `pbrMjesto` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdKorisnik`),
  KEY `pbrMjesto` (`pbrMjesto`),
  CONSTRAINT `korisnici_ibfk_1` FOREIGN KEY (`pbrMjesto`) REFERENCES `mjesto` (`pbrMjesto`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

/*Data for the table `korisnici` */

insert  into `korisnici`(`IdKorisnik`,`oibKorisnik`,`imeKorisnik`,`prezimeKorisnik`,`emailKorisnik`,`mobKorisnik`,`drzavaK`,`godStudijaST`,`statusStudenta`,`lozinka`,`indikatorSA`,`pbrMjesto`) values (1,'12345678911','Marta','Bes','marta.bes@gmail.com','0987487528','Hrvatska',1,'\0','','\0',10000),(2,'12355678912','Milivoj','Mat','milivoj.mat@gmail.com','0923485802','Hrvatska',1,'','9ee012ea8322c151576408181941188fd1402d7ed343717578e96c446a812162','\0',40000),(3,'95903526732','Ana','Marić','ana.maric@gmail.com','0987654672','Hrvatska',3,'','39e7220d702b4df6309a28352dac75d7d12231f9c35906e105976a51bdabb020','',43000),(4,'36455678939','Mia','Preko','mia.preko@gmail.com','0956789056','Hrvatska',2,'','8e21c9a3dd943328adbaf7b95b73aedf41a0e4389cd322d986efa7b045ee1f94\r\n','\0',48260),(5,'59404525042','Karlo','Car','karlo.car@gmail.com','0923403434','Hrvatska',2,'','240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9','',49250),(6,'08959190082','Luka','Vidović','luka.vidovic@gmail.com','0983423478','Hrvatska',2,'','040b6b205b811a4e2d8acf90267c43f7fa07581de94f276b4ccca55abb4cb32c','\0',48000),(7,'12345678911','Petar','Ivić','petar.ivic@gmail.com','0912345432','Hrvatska',1,'','773d44f57dc9c7c9ec9ac06e036f38211c8d61d6d3b768425963982430273f96','\0',40000),(8,'03903995089','Filip','Mat','filip.mat@gmail.com','0915678754','Hrvatska',1,'','4b4b6e82f36e3f90d60d95f22da621110e89bd8234372f25bbd096a8696c1876','\0',34550),(9,'83394414463','Anella','Rogić','anella.rogic@gmail.com','0957457515','Hrvatska',2,'','UVhiDUbn6fsfAq0ugWxQkBXQcJJ43FxCDe27HBjtNfU=','',10000),(10,'80757666398','Žan','Zuanović','zan.zuanovic@gmail.com','0978888899','Hrvatska',2,'','1r23w+WniYEX20rGwdQp/POJAoqthgShNbl3vlcYcRM=','\0',40000);

/*Table structure for table `mjesto` */

DROP TABLE IF EXISTS `mjesto`;

CREATE TABLE `mjesto` (
  `pbrMjesto` int(11) NOT NULL,
  `nazivMjesto` varchar(45) NOT NULL,
  `zupanijak` int(11) NOT NULL,
  PRIMARY KEY (`pbrMjesto`),
  KEY `fk_zupanija` (`zupanijak`),
  CONSTRAINT `fk_zupanija` FOREIGN KEY (`zupanijak`) REFERENCES `zupanija` (`zupanijak`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `mjesto` */

insert  into `mjesto`(`pbrMjesto`,`nazivMjesto`,`zupanijak`) values (10000,'Zagreb',21),(10010,'Zagreb-Sloboština',21),(10020,'Zagreb-Novi Zagreb',21),(10040,'Zagreb-Dubrava',21),(10090,'Zagreb-Susedgrad',21),(10250,'Lučko',1),(10255,'Gornji Stupnik',1),(10290,'Zaprešić',1),(10360,'Sesvete',1),(10370,'Dugo Selo',1),(10380,'Sveti Ivan Zelina',21),(10430,'Samobor',1),(10450,'Jastrebarsko',1),(20000,'Dubrovnik',19),(20210,'Cavtat',19),(20230,'Ston',19),(20242,'Oskorušno',19),(20250,'Orebić',19),(20270,'Vela Luka',19),(20340,'Ploče',19),(21000,'Split',17),(21210,'Solin',17),(21232,'Dicmo',17),(21240,'Trilj',17),(21270,'Zagvozd',17),(21310,'Omiš',17),(21400,'Supetar',17),(21420,'Bol',17),(21450,'Hvar',17),(22000,'Šibenik',15),(22010,'Šibenik-Brodarica',15),(22020,'Šibenik-Ražine',15),(23210,'Biograd na moru',13),(23250,'Pag',13),(23420,'Benkovac',13),(31000,'Osijek',14),(31300,'Beli Manastir',14),(31301,'Branjin Vrh',14),(31410,'Strizivojna',14),(31500,'Našice',14),(31530,'Podravska Moslavina',14),(31531,'Viljevo',14),(31550,'Valpovo',14),(32000,'Vukovar',16),(32100,'Vinkovci',16),(32240,'Mirkovci',16),(32280,'Jarmina',16),(33000,'Virovitica',10),(33520,'Slatina',10),(34000,'Požega',11),(34310,'Pleternica',11),(34330,'Velika',11),(34340,'Kutjevo',11),(34550,'Pakrac',11),(35000,'Slavonski Brod',12),(35210,'Vrpolje',12),(35220,'Slavonski Šamac',12),(35250,'Oriovac',12),(35420,'Staro Petrovo Selo',12),(40000,'Čakovec',20),(40320,'Donji Kraljevec',20),(42000,'Varaždin',5),(42240,'Ivanec',5),(42250,'Lepoglava',5),(43000,'Bjelovar',7),(43271,'Velika Pisanica',7),(43280,'Garešnica',7),(43290,'Grubišno Polje',7),(43500,'Daruvar',7),(43531,'Veliki Bastaji',7),(44000,'Sisak',3),(44271,'Letovanić',3),(44320,'Kutina',3),(44330,'Novska',3),(44400,'Glina',3),(44410,'Gvozd',3),(47000,'Karlovac',4),(47201,'Draganići',4),(47220,'Vojnić',4),(47240,'Slunj',4),(47251,'Bosiljevo',4),(47300,'Ogulin',4),(47302,'Oštarije',4),(48000,'Koprivnica',6),(48260,'Križevci',6),(49000,'Krapina',2),(49210,'Zabok',2),(49250,'Zlatar',2),(51000,'Rijeka',8),(51211,'Matulji',8),(51251,'Ledenice',8),(51280,'Rab',8),(51410,'Opatija',8),(51550,'Mali Lošinj',8),(52000,'Pazin',18),(52100,'Pula',18),(52420,'Buzet',18),(53000,'Gospić',9),(53230,'Korenica',9),(53250,'Donji Lapac',9);

/*Table structure for table `slike` */

DROP TABLE IF EXISTS `slike`;

CREATE TABLE `slike` (
  `idSlika` int(11) NOT NULL AUTO_INCREMENT,
  `slikaPut` blob DEFAULT NULL,
  PRIMARY KEY (`idSlika`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `slike` */

insert  into `slike`(`idSlika`,`slikaPut`) values (1,'soba1.1.jpg');

/*Table structure for table `soba` */

DROP TABLE IF EXISTS `soba`;

CREATE TABLE `soba` (
  `IdSoba` int(11) NOT NULL,
  `brojKreveta` int(11) NOT NULL,
  `velicinaSoba` int(11) DEFAULT NULL,
  `opisSobe` text DEFAULT NULL,
  `idSlika` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdSoba`),
  KEY `idSlika` (`idSlika`),
  CONSTRAINT `soba_ibfk_1` FOREIGN KEY (`idSlika`) REFERENCES `slike` (`idSlika`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `soba` */

insert  into `soba`(`IdSoba`,`brojKreveta`,`velicinaSoba`,`opisSobe`,`idSlika`) values (1,1,7,'Krevet, Ormar, Ogledalo, Stol, Stolica, Ključ, Koš za smeće, Zidna polica',1),(2,1,7,'Krevet, Ormar, Ogledalo, Stol, Stolica, Ključ, Koš za smeće, Zidna polica',NULL),(3,1,7,'Krevet, Ormar, Ogledalo, Stol, Stolica, Ključ, Koš za smeće, Zidna polica',NULL),(4,1,7,'Krevet, Ormar, Ogledalo, Stol, Stolica, Ključ, Koš za smeće, Zidna polica',NULL),(5,2,12,'2x Krevet,2x Ormar, Ogledalo,2x Stol,2x Stolica,2x Ključ, Koš za smeće,2x Zidna polica',NULL),(6,2,12,'2x Krevet,2x Ormar, Ogledalo,2x Stol,2x Stolica,2x Ključ, Koš za smeće,2x Zidna polica',NULL),(7,2,12,'2x Krevet,2x Ormar, Ogledalo,2x Stol,2x Stolica,2x Ključ, Koš za smeće,2x Zidna polica',NULL);

/*Table structure for table `uplata` */

DROP TABLE IF EXISTS `uplata`;

CREATE TABLE `uplata` (
  `IdUplata` int(11) NOT NULL AUTO_INCREMENT,
  `iznos` int(11) DEFAULT NULL,
  `datUplate` date DEFAULT NULL,
  `statusPlacanja` bit(1) DEFAULT NULL,
  `IdSoba` int(11) DEFAULT NULL,
  `opisUplata` varchar(135) DEFAULT NULL,
  `zaRazdoblje` varchar(135) DEFAULT NULL,
  `IdKorisnik` int(11) NOT NULL,
  PRIMARY KEY (`IdUplata`),
  KEY `IdSoba` (`IdSoba`),
  KEY `IdKorisnik` (`IdKorisnik`),
  CONSTRAINT `uplata_ibfk_1` FOREIGN KEY (`IdSoba`) REFERENCES `soba` (`IdSoba`),
  CONSTRAINT `uplata_ibfk_2` FOREIGN KEY (`IdKorisnik`) REFERENCES `korisnici` (`IdKorisnik`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

/*Data for the table `uplata` */

insert  into `uplata`(`IdUplata`,`iznos`,`datUplate`,`statusPlacanja`,`IdSoba`,`opisUplata`,`zaRazdoblje`,`IdKorisnik`) values (1,650,'2021-06-08','',6,'dom','lipanj',3),(4,650,'2021-06-08','\0',6,'dom','lipanj',4),(5,750,'2021-06-08','',1,'dom','lipanj',5),(6,750,'2021-06-08','\0',2,'dom','lipanj',8),(7,750,'2021-06-08','\0',3,'dom','lipanj',7),(8,750,'2021-06-08','\0',4,'dom','lipanj',6),(9,750,'2021-06-08','\0',5,'dom','lipanj',2),(11,750,NULL,'',1,'dom','srpanj',5);

/*Table structure for table `zahtjev` */

DROP TABLE IF EXISTS `zahtjev`;

CREATE TABLE `zahtjev` (
  `IdZahtjev` int(11) NOT NULL AUTO_INCREMENT,
  `statusZahtjeva` bit(1) DEFAULT NULL,
  `datPodnosenjaZahtjeva` date DEFAULT NULL,
  `datUseljenja` date DEFAULT NULL,
  `datIseljenja` date DEFAULT NULL,
  `IdSoba` int(11) DEFAULT NULL,
  `IdKorisnik` int(11) NOT NULL,
  PRIMARY KEY (`IdZahtjev`),
  KEY `IdKorisnik` (`IdKorisnik`),
  KEY `IdSoba` (`IdSoba`),
  CONSTRAINT `zahtjev_ibfk_1` FOREIGN KEY (`IdKorisnik`) REFERENCES `korisnici` (`IdKorisnik`),
  CONSTRAINT `zahtjev_ibfk_2` FOREIGN KEY (`IdSoba`) REFERENCES `soba` (`IdSoba`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

/*Data for the table `zahtjev` */

insert  into `zahtjev`(`IdZahtjev`,`statusZahtjeva`,`datPodnosenjaZahtjeva`,`datUseljenja`,`datIseljenja`,`IdSoba`,`IdKorisnik`) values (9,'','2020-07-10','2020-10-10','2021-05-25',5,6),(10,'\0','2020-07-10','2020-10-10',NULL,3,2),(11,'','2020-07-09','2020-10-10',NULL,6,3),(13,'\0','2020-07-08','2020-10-10',NULL,4,8),(14,'','2020-07-05','2020-10-10',NULL,1,5),(16,'','2020-07-10','2020-10-10','2021-01-11',2,7);

/*Table structure for table `zupanija` */

DROP TABLE IF EXISTS `zupanija`;

CREATE TABLE `zupanija` (
  `zupanijak` int(11) NOT NULL,
  `nazivZupanija` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`zupanijak`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `zupanija` */

insert  into `zupanija`(`zupanijak`,`nazivZupanija`) values (0,'Nepoznata županija'),(1,'Zagrebačka'),(2,'Krapinsko-zagorska'),(3,'Sisačko-moslavačka'),(4,'Karlovačka'),(5,'Varaždinska'),(6,'Koprivničko-križevačka'),(7,'Bjelovarsko-bilogorska'),(8,'Primorsko-goranska'),(9,'Ličko-senjska'),(10,'Virovitičko-podravska'),(11,'Požeško-slavonska'),(12,'Brodsko-posavska'),(13,'Zadarska'),(14,'Osječko-baranjska'),(15,'Šibensko-kninska'),(16,'Vukovarsko-srijemska'),(17,'Splitsko-dalmatinska'),(18,'Istarska'),(19,'Dubrovačko-neretvanska'),(20,'Međimurska'),(21,'Grad Zagreb');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
