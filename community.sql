create database community;
use community;

CREATE TABLE `user` (
  `id` varchar(15) NOT NULL,
  `passwd` varchar(15) DEFAULT NULL,
  `name` varchar(10) DEFAULT NULL,
  `email` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `board` (
  `id` varchar(15) DEFAULT NULL,
  `boardname` varchar(15) DEFAULT NULL,
  `title` varchar(20) DEFAULT NULL,
  `content` varchar(100) DEFAULT NULL,
  `date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `comment` (
  `id` varchar(15) DEFAULT NULL,
  `boardname` varchar(15) DEFAULT NULL,
  `title` varchar(20) DEFAULT NULL,
  `content` varchar(100) DEFAULT NULL,
  `comment` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `timetable` (
  `part1` varchar(15) DEFAULT NULL,
  `major` varchar(15) DEFAULT NULL,
  `subject` varchar(20) DEFAULT NULL,
  `sbno` varchar(20) NOT NULL,
  `day` varchar(20) DEFAULT NULL,
  `time` varchar(20) DEFAULT NULL,
  `location` varchar(20) DEFAULT NULL,
  `credit` int(5) DEFAULT NULL,
  `professor` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`sbno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ttresult` (
  `id` varchar(15) DEFAULT NULL,
  `sbno` varchar(20) NOT NULL,
  `day` varchar(20) DEFAULT NULL,
  `time` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양필수','드래곤실천인성','드래곤실천인성(유도)','100011-01','화','12','무-12421(유도실기장2)',1,'김판수');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('체육과학대학','기초전공','트레이닝방법론','100027-22','목','678','체-8202(시청각2실)',3,'이한경');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('무도대학','기초전공','무도철학','100035-02','화','123','체-8205',3,'김창우');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('무도대학','유도학과','메치기본(받기)','110009-05','목','78','무-12421(유도실기장2)',2,'윤익선');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('무도대학','유도경기지도학과','응급처치및구급법','110041-08','목','123','체-8205',3,'박성배');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('무도대학','동양무예학과','동양무예론','120271-12','수','123','무-12204',3,'김창우');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('무도대학','격기지도학과','전공심판법(씨름)','120313-11','화','123','보-15605',3,'이태현');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('무도대학','태권도학과','태권도지도영어','130071-13','월','123','무-12307',3,'류병관');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('무도대학','경호학과','경호학개론','140027-18','화','567','무-12307',3,'이상철');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('체육과학대학','특수체육교육학과','배구','200033-33','금','678','체-8108(체육과학실기장2)',3,'유재권');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('체육과학대학','스포츠레저학과','생활체육론','200041-25','수','123','체-8204',3,'이필영');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('체육과학대학','체육학과','기초종목상급','210017-28','월','8','운-1002',1,'성낙훈');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('체육과학대학','골프학과','전공실기실습','250003-31','월','123','골-1012(골프장)',3,'백병주');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','미디어디자인학과','색채와디자인','300001-37','화','123','문-11509(MAC실습실)',3,'김장훈');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','무용과','안무법','310091-35','월','234','문-10302(무용실기실1)',3,'한윤희');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','회화학과','서양화심화','330211-45','수','123','문-9217(회화실기실1)',3,'김선심');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','영화영상학과','현대영화사','340217-59','화','678','문-11409(시청각실)',3,'이승민');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','연극학과','프로덕션제작기초','340273-48','목','678','문-11603(뮤지컬실기실2)',3,'박미리');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','국악과','한국음악사고급','350117-58','목','123','문-10205(음악감상실)',3,'홍순옥');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','문화재학과','고고학개론','360079-61','수','123','문-11411-1',3,'김길식');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','문화콘텐츠학과','스피치와커뮤니케이션기법','380003-62','월','678','문-11702',3,'최영호');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('문화예술대학','실용음악과','화성학','390047-56','수','123','문-11613(미디강의실)',3,'정마태');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('경영행정대학','경영정보학과','경영정보시스템','400005-73','수','123','경-5311',3,'이용석');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('경영행정대학','문화관광학과','호텔경영론','430115-69','목','678','경-5209',3,'성현모');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('경영행정대학','경찰행정학과','행정학원론','460013-74','화','123','경-5207',3,'박천희');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('경영행정대학','중국학과','중국문화의이해','470005-76','목','123','환-7512',3,'이동철');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('경영행정대학','영어과','미국의역사와문화','480057-78','월','23','환-7538',3,'고경하');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','환경학과','응용화학','500003-83','목','123','환-7430',3,'김수복');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','생명과학과','기초유기화학','500009-86','화','123','환-7401',3,'이미녕');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','산업환경보건학과','산업위생학','510095-82','수','678','환-7301',3,'김판기');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('보건복지대학','식품영양학과','기초영양학','530045-88','월','678','환-7329',3,'이옥희');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','인공지능','550031-84','금','123','환-7202',3,'이중호');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','컴퓨터네트워크','550047-84','화','123','환-7217',3,'김철');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','C프로그래밍','550059-84','금','123','환-7217',3,'김철');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','소프트웨어공학','550073-84','월','123','환-7217',3,'김의찬');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','리눅스실습','550101-84','화','678','환-7217',3,'천양하');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','사물인터넷프로그래밍','550105-84','수','678','환-7217',3,'이중호');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','모바일프로그래밍','550111-84','금','678','환-7217',3,'김은화');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','이산수학','550127-84','화','123','환-7301',3,'한병준');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','실무소프트웨어프로젝트','550137-84','금','678','환-7202',3,'학과장(김철)');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','컴퓨터보안','550143-84','수','123','환-7217',3,'김철');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','데이터베이스프로그래밍','550147-84','월','678','환-7217',3,'이완주');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','윈도우어플리케이션개발기초','550171-84','월','123','환-7202',3,'김은화');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','윈도우어플리케이션개발기본','550173-84','목','123','환-7202',3,'천양하');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','윈도우어플리케이션개발고급','550175-84','화','123','환-7202',3,'이완주');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','윈도우어플리케이션개발심화','550177-84','수','123','환-7202',3,'이중호');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','컴퓨터과학과','윈도우어플리케이션개발실습','550179-84','수','678','환-7202',3,'이완주');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('환경과학대학','물류통계정보학과','고급엑셀활용법','560003-85','월','123','환-7209',3,'김용철');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('보건복지대학','물리치료학과','신경물리치료학개론','570105-89','수','123','보-15401',3,'황병용');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('보건복지대학','사회복지학과','노년학','580075-90','수','123','보-15704',3,'정미경');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('보건복지대학','뷰티케어학과','네일아트테크닉','600017-92','화','123','경-5414',3,'윤은기');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('체육과학대학','뷰티헬스케어학과','뷰티메이크업테크닉','600019-34','화','678','경-5414',3,'김현진');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('군사학','전체','국가안보론','800001-01','월','78','무-12202',2,'이성춘');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양필수','사고와표현','사고와표현','910001-01','월','23','환-7109',2,'최윤정');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양필수','컴퓨터활용','컴퓨터활용','910013-02','월','5','경-5309',1,'천양하');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양필수','컴퓨터활용','컴퓨터활용','910013-06','화','5','경-5309',1,'김은화');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양필수','English2','English2','910021-49','목','5','경-5B101',2,'웬월스윌리엄');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양필수','English4','English4','910037-04','수','3','체-8325',2,'밴혼카일');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양필수','스포츠경영의이해','스포츠경영의이해','910051-01','금','23','무-12101(무도세미나실)',2,'김중헌');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양선택','교양1영역','철학산책','920021-01','목','678','보-15103',3,'이동철');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양선택','교양3영역','알기쉬운한국정치','920041-04','화','678','보-15603',3,'최창렬');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양선택','교양7영역','현대창업자의리더쉽','920049-01','목','123','경-5201',3,'유선권');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양선택','교양6영역','실용생명과학','920061-01','월','678','환-7401',3,'이웅빈');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양선택','교양5영역','연극으로만나는나','920213-02','수','678','문-9503(연극스튜디오2)',3,'정은선');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교양선택','교양2영역','미디어영어2','920235-01','월','678','환-7302',3,'임남실');
INSERT INTO `timetable` (`part1`,`major`,`subject`,`sbno`,`day`,`time`,`location`,`credit`,`professor`) VALUES ('교직','전체','교육사회','960003-01','수','78','보-15601',2,'장재천');