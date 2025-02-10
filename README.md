این مطلب را برای دوستانی تهیه نمودم ،که چندین سال است  با T-SQL کار کرده اند و میخواهند با دیتابیسس  منگو تازه کار کنند .
در واقع برای فهم بهتر تمام اجزا ، به صورت معادل یکدیگر در نظر گرفته میشود 


داده ها تستی ما به صورت زیر در دیتابیس منگو ذخیره شده است




از کوئری  ساده شروع و  کم کم به کوئری پیچیده میرسیم.توضیح هر کدام در جلوی هر کوئری نوشته شده است


t-sql : select *  from city
mongodb: db.city.find({});
تمام اطلاعاتی را میخواهم نمایش دهد که در جدول city ذخیره شده است


t-sql:select name from  city
mongodb: db.city.find({ }, {_id:0, name: 1 } );
نام شهر که در جدول city ذخیره شده را نمایش دهد


t-sql: select distinct name  from city
mongodb:db.city.distinct("name");
نام شهر های که در جدول city ذخیره شده  ،تکرارای نمایش ندهد




t-sql: SELECT * FROM city WHERE name='London';
mongo: db.city.find({ name: 'London' });
تمام اطلاعاتی را میخواهم به شرط آنکه نام شهر آن برابر با لندن باشد


t-sql : SELECT * FROM city WHERE  population> 80;
mongodb : db.city.find({ population: { $gt: 80 } });
تمام اطلاعاتی که جمعیت آنها بیشتر از 80 باشد


SELECT * FROM city WHERE population< 80;
 db.city.find({ population: { $lt: 80 } });
تمام اطلاعاتی که جمعیت آنها کمتر از 80 باشد




SELECT * FROM city WHERE population<= 80;
db.city.find({ population: { $lte: 80 } });
تمام اطلاعاتی که جمعیت آنها کمتر و مساوی از 80 باشد




SELECT * FROM city WHERE population >= 80;
db.city.find({ population: { $gte: 80 } });
تمام اطلاعاتی که جمعیت آنها بیشتر و مساوی از 80 باشد




SELECT * FROM city WHERE population  !=  80;
db.city.find({ population: { $ne: 80 } });
تمام اطلاعاتی که جمعیت برابر  80 نباشد


SELECT * FROM city WHERE population > 49 AND population < 50;
db.city.find({population:{$gt:49,$lt:50}});
تمام اطلاعاتی که جمعیت آنها  بین 49 تا 50 باشد نمایش بده
select * from City where name like "%lon%"
db.city.find({ name: { $regex: "lon", $options: "i" } })
تمام شهرهای را نمایش بده که حروف lon در آن وجود داشته باشد
select * from city where name like "Lo%"
db.city.find({ name: { $regex: /^Lo/ } })
or 
db.city.find({ name:  /^Lo/  })
تمام شهر های که با حروف Lo شروع میشود


t-sql:select * from city where name like "%don"
 mongodb:db.city.find({ name: { $regex: "don$", $options: "i" } })
تمام شهر های که با حروفdon  پایان میابد


t-sql: SELECT * FROM city ORDER BY name;
mongodb:db.city.find({ }).sort({ "name": 1 });
تمام اطلاعاتی را میخواهم که بر اساس   نام شهر آن مرتب شده باشد


SELECT * FROM city ORDER BY name DESC;
db.city.find().sort({name: -1})
تمام اطلاعاتی را میخواهم که بر اساس   نام شهر به صورت نزولی مرتب شده باشد




t-sql:select *  from   city  where name in  ('London','Coulsdon')
mangodb:db.city.find({ name: { $in: ['London', 'Coulsdon'] } })
شهرهای را نمایش بده که شامل London , Coulsdon باشد

INSERT  Customers (CustomerName, ContactName) VALUES('Cardinal', 'Tom B. Erichsen');
 db.city.insertOne({ CustomerName: 'Cardinal', ContactName: 'Tom B. Erichsen' });

درج کردن اطلاعات در جدول city




UPDATE city SET Name = 'ardabil' WHERE city = 'London';
db.city.updateOne( { name: 'London' }, { $set: { name: 'ardabil' } } )
ویرایش نام شهر به ardbil به شرط آنکه نام آن برابر london باشد



  
DELETE FROM  city WHERE Name='ardabil'
 db.city.deleteOne({ name:"ardabil"})
حذف سطر که نام شهر آن ardabil باشد


db.city.updateMany({}, { $rename: { "name": "cityname" } } ,false,true); 
تغییر نام فیلد name , cityname در  mongo db

  
