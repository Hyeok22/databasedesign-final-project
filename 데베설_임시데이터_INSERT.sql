#drop table bookmark, menu, review, reviewimage, store, storecategory, storeimage, user;

###########################
# User, Bookmark, Review, rollback, Menu, Store, StoreCategory, StoreImage
use temp;
show tables;
create table User (userno int auto_increment primary key,
					email varchar(45) unique not null,
                    password varchar(45) not null,
                    username varchar(30) not null,
                    tel varchar(45),
                    createdAt timestamp Default CURRENT_TIMESTAMP,
                    updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP);

create table StoreCategory(categoryno int auto_increment primary key,
							name varbinary(45) not null,
                            imgurl text,
                            createdAt timestamp Default CURRENT_TIMESTAMP,
							updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP);

create table Store(storeno int auto_increment primary key,
					name varchar(45) not null,
                    tel varchar(45),
                    address varchar(60),
                    openhour time,
                    closehour time,
                    introduction varchar(255),
                    notice varchar(255),
                    categoryno int,
                    createdAt timestamp Default CURRENT_TIMESTAMP,
                    updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    foreign key(categoryno) references StoreCategory(categoryno)
                    );

create table StoreImage(imgno int auto_increment primary key,
						imgurl text not null,
                        storeno int,
                        createdAt timestamp Default CURRENT_TIMESTAMP,
						updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                        foreign key(storeno) references Store(storeno));

create table Menu(menuno int auto_increment primary key,
					name varchar(45) not null,
                    price int not null,
                    introduction varchar(255),
                    storeno int,
                    createdAt timestamp Default CURRENT_TIMESTAMP,
                    updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    foreign key (storeno) references Store(storeno));

create table Bookmark(bookmarkno int auto_increment primary key ,
					userno int, 
                    storeno int,
                    createdAt timestamp Default CURRENT_TIMESTAMP,
                    updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    foreign key (userno) references User(userno),
                    foreign key (storeno) references Store(storeno)
                    );
				
create table Review(reviewno int auto_increment primary key,
					content varbinary(255),
                    rating double,
                    userno int,
                    storeno int,
                    createdAt timestamp Default CURRENT_TIMESTAMP,
                    updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    foreign key (userno) references User(userno),
                    foreign key (storeno) references Store(storeno)
                    );

create table ReviewImage(imageno int auto_increment primary key,
						imageurl text not null,
                        reviewno int,
                        createdAt timestamp Default CURRENT_TIMESTAMP,
						updatedAt timestamp Default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                        foreign key (reviewno) references Review(reviewno)
                        );
                        

# admin 계정 생성, store 테이블 채우기
# admin 계정 생성
insert into user(email, password, username, tel, createdAt, updatedAt) values('admin@boss.com', '123', 'admin', '010-1234-1234', now(), now());

# storecategory
insert into storecategory(name, createdAt, updatedAt) values('한식', now(), now());
insert into storecategory(name, createdAt, updatedAt) values('분식', now(), now());
insert into storecategory(name, createdAt, updatedAt) values('디저트', now(), now());
insert into storecategory(name, createdAt, updatedAt) values('일식', now(), now());
insert into storecategory(name, createdAt, updatedAt) values('치킨', now(), now());
insert into storecategory(name, createdAt, updatedAt) values('피자', now(), now());
-- insert into storecategory(name, createdAt, updatedAt) values('양식', now(), now()); 
insert into storecategory(name, createdAt, updatedAt) values('중식', now(), now());
-- insert into storecategory(name, createdAt, updatedAt) values('족발', now(), now());
-- insert into storecategory(name, createdAt, updatedAt) values('찜탕', now(), now());
insert into storecategory(name, createdAt, updatedAt) values('도시락', now(), now());
insert into storecategory(name, createdAt, updatedAt) values('패스트푸드', now(), now());
select * from storecategory;

# 식당 insert
#공백없이 
# 한식 2->1 6~10 -> 1~5
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('필동면옥', '서울 중구 서애로 26', '02-2266-2611', '냉면을 먹기 전에 꼭 먹어줘야 하는 만두와 편육. 평양식 만두는 먹음직스러운 크기에 꽉찬 만두 속맛이 제격이고,편육은 질 좋은 고기를 잘 삶아서 독특한 새우젓 양념에 살짝 찍어 먹는 것이 일품이랍니다.', 1, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('황토골', '서울 중구 서애로 6-1', '010-3368-1384', '점심특선 메뉴로 오후 2시 20분까지만 준비해드리고있습니다!', 1, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('김치만 선생', '서울 중구 필동로 30-1', '02-6052-5526', 1, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('기호네 곱창', '서울 중구 퇴계로44길 8-10 1층', '02-2274-6992', '기호네곱창 충무로점입니다.', 1, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('대청마루', '서울 중구 퇴계로44길 16', '02-2285-2650', 1, now(), now());

select * from store;

# 분식 3->2 11~15 -> 5~10
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('꽃사슴떡볶이', '서울 중구 동호로25길 3', '02-2264-8525', '양은냄비에 끓여주는 매콤 달콤한 즉석 떡볶이가 유명한 분식점입니다.', 2, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('왕순이김밥', '서울 중구 서애로1길 11 해센스마트 112호', '02-2263-2600', '안녕하세요~ 항상 맛과 정성으로 보답하는 왕순이김밥 동국대점 입니다~', 2, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('신전떡볶이', '서울 중구 퇴계로 247 2층', '02-2273-8167', 2, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('솜이네떡볶이', '필동2가 22-4', '0507-1399-2468', 2, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('남산김밥', '서울 중구 퇴계로 188', '0507-1361-1880', '햄맛살을쓰지않고어묵과깻잎을씀니다', 2, now(), now());

select * from store;

# 카페 5->3 21~25 -> 11~15
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('태극당', '서울 중구 동호로24길 7', '02-2279-3152', '서울에서 가장 오래된 빵집. 1946년부터 지금까지 빵을 구웠습니다.', 3, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('블루포트', '서울 중구 필동로1길 30 본관 1층', '02-2260-8970', '저희 블루포트는 저렴한 가격과 훌륭한 맛과 품질을 제공하고 있습니다.', 3, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('충무로한옥카페달강', '서울 중구 퇴계로34길 28 남산골 한옥마을 남산국악당', '0507-1347-5280', '멋진 정원 뷰 한옥카페', 3, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('노띵커피', '서울 중구 퇴계로50길 33-2', '02-303-7404', '서울의 중심이지만 골목 따라 오래된 인쇄소와 키작은 건물들이 모여 있는 곳입니다. ', 3, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('포미스커피', '서울 중구 서애로 14-1', '02-2275-2761', '거품없는 가격 충무로의 귀여운 핫플레이스', 3, now(), now());

select * from store;

# 일식 4->4
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('낙원의소바', '서울 중구 서애로 2 2층', '0507-1438-3018', '안녕하세요. 새로운 곳에서 시작하는 저희 낙원의소바는 최고의 메밀국수를 제공한다는 모토로 다양한 창작요리를 제공하고 있습니다.', 4, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('백소정동국대점', '서울 중구 서애로1길 11 1층 101호', '0507-1438-2294', '안녕하세요 백소정 동국대점입니다!', 4, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('신승호라멘집', '서울 중구 필동로 22 1층', '0507-1351-9528', 4, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('오이드킨', '서울 중구 서애로1길 2 2층 오이드킨', '0507-1399-1998', '저희 가게는 프리미엄 숯불을 이용한 숯불 요리 덮밥 전문점입니다', 4, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('모리짱', '서울 중구 서애로 12 충무로 5가 85-4 지하1층', '02-2271-0393', '라멘 .돈부리. 각종 일본풍 술안주 하이볼. 사케. 생.병맥주.소주', 4, now(), now());

select * from store;

# 치킨 1->5 1~5 -> 21~25
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('우리안치킨', '서울 중구 퇴계로44길 5', '02-2285-2446', '충무로에서 낮술을 즐길수있는 편안한 호프집으로 충무로역1번출구70미터',  5, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('BHC치킨충무로역점', '서울 중구 퇴계로 210', '050-7982-3010', '운영시간/휴무일은 매장상황에 따라 변동될 수 있습니다. 매장으로 확인 부탁드립니다.',  5, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('BBQ치킨동국대점', '서울 중구 서애로 2 다인빌딩 1층', '02-2272-8992', '안녕하세요. 고객의 행복을 키우는 BBQ입니다.',  5, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('브라운호프', '서울 중구 퇴계로 252-1', '02-2279-0271',  5, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('브아브아', '서울 중구 퇴계로 197 충무빌딩 지층 1012호', '0507-1414-7819', '충무로 인쇄골목내 숨은 수제맥주 전문점입니다.',  5, now(), now());

select * from store;

# 피자 6->6
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('잭슨빌피자', '서울 중구 서애로1길 12 2층', '0507-1355-9580', '빵끝까지 맛있는 잭슨빌 피자!!', 6, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('미스터피자', '서울 중구 서애로 12 1층', '0507-1388-0284', 6, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('빽보이피자', '서울 중구 필동로 31', '02-2275-1905', 6, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('파파존스', '서울 중구 퇴계로 197 1층 104호', '02-2265-8236', '파파존스는 미국 3대 대표 피자브랜드이며 더 좋은 재료, 더 맛있는 피자를 기업 이념으로 삼고, 고객들에게 가장 맛있고 뛰어난 품질의 피자를 제공하는 것에 최고의 가치를 두고 있습니다.', 6, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('도치피자', '서울 중구 동호로24길 27-6', '0507-1400-8005', '화덕피자가 국내에 생소하던 시절 선구자적 역할을 하며 화덕피자를 국내에 유행시킨 터줏대감.', 6, now(), now());

select * from store;

# 양식 7->x
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('필동함박', '서울 중구 필동로 7-1 1층 필동함박 본점', '070-8656-6606', '백종원의 골목식당 맛집 필동함박입니다', 7, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('바로파스타마켓', '서울 중구 퇴계로 210-14', '0507-1301-0355', '오늘도 정성스럽게 준비하여 오픈했습니다!', 7, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('서울다이닝', '서울 중구 동호로 272 디자인하우스', '02-6325-6321', '5인이상 예약은 전화문의!', 7, now(), now());
-- insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
-- values('코너스테이크', '서울 중구 퇴계로 218-16', '02-4628-2204', 7, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('럭키서울', '서울 중구 창경궁로1길 14 105호', '02-2273-0337', '여행자 숙소의 여행자 식당', 7, now(), now());

-- select * from store;

# 중식 8->7 36~40 -> 31~35
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('라화방마라탕', '서울 중구 서애로1길 10', '02-2272-7792', '마라탕 원조 맛집~!', 7, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('홍짜장', '서울 중구 서애로1길 11', '02-2261-4484', 7, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('강서', '서울 중구 서애로1길 6', '02-2266-0466', '화교가 직접 운영하는 오래 된 전통을 자랑하는 곳이다.', 7, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('태화루', '서울 중구 퇴계로50길 37', '02-2266-2876', 7, now(), now());
insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
values('필동반점', '서울 중구 필동로 15-6', '02-2272-2782', 7, now(), now());

select * from store;

# 족발 9->x
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('필동족발', '서울 중구 필동로 29 필동족발', '02-2272-0592', '필동족발', 9, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('장수족발', '서울 중구 서애로 13-2', '02-2277-8847', '예약 가능!', 9, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('평안도족발집', '서울 중구 장충단로 174-6', '02-2279-9759', '포장 가능!', 9, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('뚱뚱이할머니집', '서울 중구 장충단로 174-1', '0507-1333-2714', '저희 매장은 매주 화요일 휴무입니다.', 9, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('장충족발집', '서울 중구 장충단로 170-5', '02-2268-0325', '배달 가능!', 9, now(), now());

-- select * from store;

# 찜탕 10->x
-- insert into store(name, address, introduction, categoryno, createdAt, updatedAt) 
-- values('내가찜한닭', '서울 중구 서애로 6-1 인산빌딩', '최고의 맛과 최상의 서비스를 제공하겠습니다.', 10, now(), now());
-- insert into store(name, address, tel, categoryno, createdAt, updatedAt) 
-- values('경동생삼겹묵은지등갈비찜', '서울 중구 퇴계로41길 8', '02-2278-8755', 10, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('머거보까매운갈비찜', '서울 중구 다산로10길 5-4', '02-2234-4544', '안녕하세요. 머거보까매운갈비찜 입니다', 10, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('약수동해물텀벙', '서울 중구 다산로10길 11', '0507-1344-9588', '대한민국 아구찜 빅테이터 맛집 BEST 3 선정', 10, now(), now());
-- insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
-- values('미나리아구', '서울 중구 다산로 105 1층', '02-2232-6707', '안녕하세요. 미나리 아구 입니다!', 10, now(), now());

-- select * from store;

# 도시락 11->8 51~55 -> 36~40
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('본도시락', '서울 중구 퇴계로50가길 6-9 1층', '02-2269-4282', '많은 이용 바랍니다', 8, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('한솥도시락', '서울 중구 서애로1길 26', '02-2272-2224', '혼밥 맛집', 8, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('봉구스밥버거', '서울 중구 필동로 15-3', '02-2232-7999', '예약 가능!', 8, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('샐러디', '서울 중구 서애로1길 11', '02-2275-1571', '건강한 패스트푸드, 샐러디', 8, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('프레시크레딧', '서울 중구 충무로 3 B1층 109호', '0507-1334-3398', '안녕하세요.', 8, now(), now());

select * from store;

# 패스트푸드 12->9 56~59 -> 41~44
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('버거킹', '서울 중구 퇴계로 216', '02-2285-0337', '식약처 인증 위생등급 매우우수 음식점', 9, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('맘스터치', '서울 중구 서애로1길 11', '0507-1317-9150', '맘스터치', 9, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('KFC', '서울 중구 퇴계로 213', '02-2275-1661', '치킨은 다양한 부위로 매장에서 제공되는 점 양해 바랍니다.', 9, now(), now());
insert into store(name, address, tel, introduction, categoryno, createdAt, updatedAt) 
values('노브랜드버거', '서울 중구 필동로1길 30', '0507-1348-8966', 'NoBrand Burger!', 9, now(), now());

select * from store;

use temp;
select * from store;
select * from user;
select * from review;
/*
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('', , , , now(), now());
*/
-- 31 ~ 35, 41 ~ 45, 46 ~ 50 지워
/*
6~10 -> 1~5
11~15 -> 6~10
21~25 -> 11~15
16~20 ->16~20
1~5 -> 21~25
26~30 -> 26~30
36~40 -> 31~35
51~55 -> 36~40
56~59 -> 41~44
*/
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('제육이 보들보들 하면서 쫄깃쫄깃 해서 맛있습니다 또 방문 하고 싶네요', 4, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('도톰한 삼겹살과 물냉면 너무 맛있어요', 4, 1, 2, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('가성비 좋구 양도 많고 점심 메뉴로 좋아요.', 4, 1, 3, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('바빠서 한동안 못먹었는데 여전히 맛있습니다.ㅎㅎ', 4, 1, 4, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('가성비가 너무 좋아요!!', 4, 1, 5, now(), now());

select * from review;

insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('가성비가 너무 좋아요!!', 4, 1, 6, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('학교 앞이라 그런지 메뉴가 다양하고 가격이 괜찮더라고요', 5, 1, 7, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('생각보다 매장이 넓고 좋더라구요.', 4, 1, 8, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('양진짜 많아요!!!', 4, 1, 9, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('양이 많아요 편히먹을수있아영', 4, 1, 10, now(), now());

insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('역사와 추억이 있는 빵집!', 4, 1, 11, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('가성비대비 맛도 괜찮아요', 4, 1, 12, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('남산 한옥마을 안 카페 분위기 좋고 전경 좋고..', 5, 1, 13, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('내부 깨끗하고 아늑해요 ㅎㅎㅎ 커피도 맛있고 사장님들도 친절하십니다 ^0^', 4, 1, 14, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('여기 쿠키 정말 맛있어요', 5, 1, 15, now(), now());

insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('단연코 충무로역 돈까스맛집 찾으시면 강추드리고싶은 곳!', 4, 1, 16, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('맨날 돈까스만 먹다가 스페셜 카츠동 시켜봤는데 너무 맛있네용', 4, 1, 17, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('사장님도 친절하시고 츠케소바도 상당히 괜찮았습니다.^^', 4, 1, 18, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('혼밥하기 좋게 바 테이블이 있고 음식도 맛있어요~', 5, 1, 19, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('항상 깔끔한 식당 내부에서 담백한 사케동 잘 먹었습니다^^', 5, 1, 20, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)

values('양이 많아서 듀마리같은 한마리입니당 !! 어니언? 너뮤 맛있었어요', 5, 1, 21, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('직장인 불금 런치는 치맥이쥬~ㅎㅎㅎ 맛있어요.', 4, 1, 22, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('너무 맛있어보여서 먹느라 사진을 미처 못 찍었네요 ㅠ', 4, 1, 23, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('리뷰가 다 좋지만 너무 기대는 하지말자 하면서 들어가는 순간 시간여행하는 느낌이었어요.', 5, 1, 24, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('맥주는 당연 좋고 안주 먹태도 정말 좋았어요 !', 4.5, 1, 25, now(), now());

insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('페스츄리 진짜 짱짱맨!!!', 5, 1, 26, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('미스터피자는 충무로점 최고', 5, 1, 27, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('처음 먹는데 생각보다 맛있었어요', 4, 1, 28, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('파파존스 너무 맛있어용', 5, 1, 29, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('오픈 키친이라 더 믿고 먹을 수 있어요', 5, 1, 30, now(), now());

-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('조용한 분위기에 조도도 따뜻하고 직 원분들도 친절해서 기분이 좋았어요!', 4.13, 1, 31, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('메뉴도 저렴하고 모두 맛있어요!', 4.44, 1, 32, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('요리마다 재료 궁합을 듣고 이해하며 맛 느끼는 미슐랭 가이드 파인 다이닝 식당!', 4.79, 1, 33, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('부드럽고 맛있네요^^', 4.17, 1, 34, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('병원갔다가 들러 맛있게 잘먹었어요.', 4.34, 1, 35, now(), now());

insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('돌고돌아 마라는 라화방!', 4, 1, 31, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('찹쌀탕수육 바로튀겨나온듯 맛있고 양이 많아요', 4, 1, 32, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('간짜장 건더기가 큼지막하고 많이 들었음 고기튀김 깔-끔 굿', 5, 1, 33, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('달지 않은 간짜장, 매끈 쫄깃 하지 않 고 약간 거친 듯 찰기 적은 면 맛있어요', 4, 1, 34, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('회사앞 최애중국집 숙주양이 많아 해장하기 딱 조아요', 5, 1, 35, now(), now());

-- values('앞발 반반에 호박전 시켜서 네명이 배터지게 먹었어요~', 4.76, 1, 41, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('찐 족발 맛집입니다!!', 4.16, 1, 42, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('족발이 아주 부드럽고 맛있어서 감탄 하며 먹었어요', 4.12, 1, 43, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('운좋게 따끈 따끈 김이 폴폴 갓 나온 족발~!', 4.64, 1, 44, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('주차걱정도 없고 친절하시고 족발 냄새도 안 나고 맛있어요!', 3.89, 1, 45, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('찜닭이 맛있어요', 4.11, 1, 46, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('너무 친절하시고 음식도 맛있어요~', 4.25, 1, 47, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('매운맛에 중독돼요~', 4.36, 1, 48, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('최고 맛집! 밑반찬도 다 맛있어요~', 4.66, 1, 49, now(), now());
-- insert into review(content, rating, userno, storeno, createdAt, updatedAt)
-- values('쭈꾸미 보리밥정식 맛있게 먹었어요', 4.12, 1, 50, now(), now());

insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('가격은 다소 있지만 특별한 혼밥하기 좋아요', 4, 1, 36, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('김피탕~~ 맛있어요~', 5, 1, 37, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('맛나요~~~ 간단히 먹기좋음', 4, 1, 38, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('맛있게 잘 먹엇어요! 친절하셔서 좋아요', 4, 1, 39, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('프레시크레딧 충무로점. 맛있는 식사를 판매해서 아주 든든합니다.', 4, 1, 40, now(), now());

insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('오랜만에 햄버거로 맛있게 저녁먹었어요', 5, 1, 41, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('양념치킨 반마리 혼자서 먹기에 무난하고 양념이 자극적이지 않아서 좋았습니다', 4, 1, 42, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('KFC 치킨은 먹어봤어도 햄버거는 처음인데 맛있어요!', 5, 1, 43, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('버거 맛있는데 학식이 확실히 가성비는 훨씬 좋네요.', 4, 1, 44, now(), now());


#리뷰 추가
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('기본에 충실한! 평양냉면 이었습니다!', 4, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('왜 유명한지 알 거 같아요,,', 5, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('매번 혼자 가보다가 친구끌고 재방문했습니다.', 4, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('일행이 모두 와야 입장 가능', 3, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('날이 슬슬 더워지니 줄이 더 길어지는 듯 해요', 3, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('슴슴한 평양냉면의 끝판왕', 5, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('다음에는 꼭 친구 한 명 잡아와서 제육시켜 먹어보고 싶네요.', 5, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('또가서 먹어보고싶은 생각나는 맛입니다^^', 4, 1, 1, now(), now());
insert into review(content, rating, userno, storeno, createdAt, updatedAt)
values('No review for this restaurant!', 5, 1, 1, now(), now());

select * from review;

#즐겨찾기 추가
insert into bookmark(userno, storeno, createdAt, updatedAt)
values(1, 1, now(), now());
insert into bookmark(userno, storeno, createdAt, updatedAt)
values(1, 6, now(), now());
insert into bookmark(userno, storeno, createdAt, updatedAt)
values(1, 11, now(), now());
insert into bookmark(userno, storeno, createdAt, updatedAt)
values(1, 16, now(), now());
insert into bookmark(userno, storeno, createdAt, updatedAt)
values(1, 21, now(), now());