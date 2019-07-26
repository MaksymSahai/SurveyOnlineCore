use SO_DataBase
Insert into SO_DataBase.dbo.Customers(CustomerId, CustomerName, CustomerEmail, CustomerPassword, CustomerSalt, CustomerAbilities)
values ('cca0cdff-3430-4271-8063-e30c16fae4e2', 'Customer Name 1', 'customer@email.com', 'testpassword', 'testsalt', 'test abilities');
go

Insert into SO_DataBase.dbo.Surveys(SurveysId, SurveyName, SurveyDescription, SurveyStatus, SurveyUrl, CustomerId)
values ('82077383-9629-463b-8fb4-352a1fd24412','Survey Name 1','Survey Description 1',1 ,'survey-url-1','cca0cdff-3430-4271-8063-e30c16fae4e2'),
('3f24102a-d091-41d6-88ec-a13a29ed7f0e','Survey Name 2','Survey Description 2',0 ,'survey-url-2','cca0cdff-3430-4271-8063-e30c16fae4e2')
go

Insert into SO_DataBase.dbo.QuestionTypes(QuestionTypeId, QuestionTypeName,  QuestionTypeDescription)
values ('ea888a7d-1fde-4fa7-bdac-7f240ca762f6','Test type 1','Test type desc 1'),
('b4d59c13-c2bd-4654-a8a3-6e5cc00fb3c5','Test type 2','Test type desc 2')
go

Insert into SO_DataBase.dbo.Questions(QuestionId, QuestionName, QuestionTypeId, SurveysId)
values('89e0dc1d-f943-49ca-9bdb-e83a3a5fbc56','Test Question 1','ea888a7d-1fde-4fa7-bdac-7f240ca762f6','82077383-9629-463b-8fb4-352a1fd24412'),
('c5ea9c17-30dd-4192-bd08-df427fef88f3','Test Question 2','ea888a7d-1fde-4fa7-bdac-7f240ca762f6','82077383-9629-463b-8fb4-352a1fd24412'),
('0d2ba192-1fb2-4ff4-a3ad-60187d8e98f5','Test Question 3','b4d59c13-c2bd-4654-a8a3-6e5cc00fb3c5','82077383-9629-463b-8fb4-352a1fd24412'),
('7dd3fdc9-2b6e-45f7-bc59-40dccaa8eb65','Test Question 4','b4d59c13-c2bd-4654-a8a3-6e5cc00fb3c5','82077383-9629-463b-8fb4-352a1fd24412')
go

Insert into SO_DataBase.dbo.AnswerVariants(AnswerVariantId, AnswerVariantName, QuestionId)
values ('07391a45-37ed-4277-840d-8520ef26b7d2','Test answer 1 for  question 1','89e0dc1d-f943-49ca-9bdb-e83a3a5fbc56'),
('bbdb141d-41de-4dc1-8755-53df167f58e0','Test answer 2 for  question 1','89e0dc1d-f943-49ca-9bdb-e83a3a5fbc56'),
('90e60f7c-ce89-4be8-9556-cc0b120985ee','Test answer 3 for  question 1','89e0dc1d-f943-49ca-9bdb-e83a3a5fbc56'),
('20ce2e73-6bd2-4a61-a49b-e3a151b334d0','Test answer 4 for  question 1','89e0dc1d-f943-49ca-9bdb-e83a3a5fbc56'),
('a43fb395-98d6-4577-8187-42a3bb4f3d75','Test answer 1 for  question 2','c5ea9c17-30dd-4192-bd08-df427fef88f3'),
('f253a6ac-6bed-4afe-92af-b5df6ecf6b82','Test answer 2 for  question 2','c5ea9c17-30dd-4192-bd08-df427fef88f3'),
('ef38b6a9-9832-4a81-9976-8e6cd39fb4a1','Test answer 3 for  question 2','c5ea9c17-30dd-4192-bd08-df427fef88f3'),
('50d045f7-1543-4401-a7b8-cb9af2ab5363','Test answer 1 for  question 3','0d2ba192-1fb2-4ff4-a3ad-60187d8e98f5'),
('04a5c4bf-a45c-48aa-a827-4e813b8d7166','Test answer 2 for  question 3','0d2ba192-1fb2-4ff4-a3ad-60187d8e98f5'),
('47b48a97-8f1c-43bb-9c16-cb230e8ec2c6','Test answer 1 for  question 4','7dd3fdc9-2b6e-45f7-bc59-40dccaa8eb65'),
('752b6678-8dba-4b9a-be91-d3e37d3b9790','Test answer 2 for  question 4','7dd3fdc9-2b6e-45f7-bc59-40dccaa8eb65'),
('a37eacda-1f6e-4a6e-bce3-5067dcb4bd1d','Test answer 3 for  question 4','7dd3fdc9-2b6e-45f7-bc59-40dccaa8eb65')
go