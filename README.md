# APILap2
connect lab1 to database


these are the api call

-----------------------------------------------------
Get
https://localhost:7013/api/Animals

--------------------------------------
post
https://localhost:7013/api/Animals
{
  
  "AnimalTypeId": 2,
  "AnimalName": "soosy",
  "DateOfBirthDay": "2021-12-22T21:37:51.093Z"
  
}


------------------------------------------
put
https://localhost:7013/api/Animals/8
{
  "Id": 8,
  "Name": "sssss",
  "DateOfBirth": "2021-11-22T21:37:51.093Z",
	"AnimalType": {
		"Id": 2,
		"Name": "dog"
	}
  
}
---------------------------------------------
delete
https://localhost:7013/api/Animals/8

