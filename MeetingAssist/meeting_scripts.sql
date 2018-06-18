--table ddls

CREATE TABLE "MEETING"
(
  "MEETING_ID" integer NOT NULL DEFAULT nextval('"MEETING_MEETING_ID_seq"'::regclass),
  "ROOM_ID" numeric NOT NULL,
  "ORGANIZER_ID" numeric NOT NULL,
  "DESCRIPTION" character varying(128) NOT NULL,
  "AGENDA" character varying(256) NOT NULL,
  "TO_DATE_TS" timestamp without time zone NOT NULL,
  "FROM_DATE_TS" timestamp without time zone NOT NULL,
  CONSTRAINT "PKEY" PRIMARY KEY ("MEETING_ID")
);


CREATE TABLE "MEETING_PARTICIPANT"
(
  "MEETING_ID" numeric NOT NULL,
  "PARTICIPANT_ID" numeric NOT NULL
);


CREATE TABLE "MEETING_ROOM"
(
  "ROOM_ID" integer NOT NULL DEFAULT nextval('"MEETING_ROOMS_ROOM_ID_seq"'::regclass),
  "ROOM_NAME" character varying(128) NOT NULL,
  CONSTRAINT "MR_PKEY" PRIMARY KEY ("ROOM_ID")
);

CREATE TABLE "USER"
(
  "USER_ID" integer NOT NULL DEFAULT nextval('"USER_USER_ID_seq"'::regclass),
  "NAME" character varying(128) NOT NULL,
  "MAILID" character varying(128) NOT NULL,
  "LOGIN_ID" character varying(64) NOT NULL,
  CONSTRAINT "U_PKEY" PRIMARY KEY ("USER_ID"),
  CONSTRAINT "U_ALTKEY" UNIQUE ("LOGIN_ID")
);


--static data for testing

INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (1,'Charles Babbage'  , 'Charles.Babbage@Computer.com'  , 'chbabb'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (2,'Claude Shannon'  , 'Claude.Shannon@IT.com'  , 'clshan'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (3,'Dennis Ritchie'  , 'Dennis.Ritchie@C.com'  , 'deritc');
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (4,'Ken Thompson'  , 'KenThompson@UNIX.com'  , 'kethomp');
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (5,'Brian Kernighan'  , 'BrianKernighan@Unix.com'  , 'brkernig'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (6,'Bjarne Stroustrup'  , 'BjarneStroustrup@CPP.com'  , 'bjstroust'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (7,'James Gosling'  , 'JamesGosling@JAVA.com'  , 'jagosl'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (8,'Richard Stallman'  , 'RichardStallman@GNU.com'  , 'ristall'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (9,'Steve Jobs'  , 'SteveJobs@Apple.com'  , 'stjobs'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (10,'Bill Gates'  , 'BillGates@Microsoft.com'  , 'biga'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (11,'Linus Torvalds'  , 'LinusTorvalds@Linux.com'  , 'litorva'); 
INSERT INTO "USER"("USER_ID","NAME","MAILID","LOGIN_ID") VALUES (12,'Aparna Kesavan'  , 'Aparna.K.Menon@gmail.com'  , 'aparn');  
 

INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL1 ROOM1'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL1 ROOM2'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL1 ROOM3'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL2 ROOM1'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL2 ROOM2'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL2 ROOM3'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL2 ROOM4'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL3 ROOM1'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL3 ROOM2'); 
INSERT INTO "MEETING_ROOM"("ROOM_NAME") VALUES('LEVEL3 ROOM3'); 
