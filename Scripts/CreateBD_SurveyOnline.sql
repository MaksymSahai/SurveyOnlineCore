CREATE DATABASE SO_DataBase
GO
use SO_DataBase
GO

CREATE TABLE Customers
(
	CustomerId uniqueidentifier PRIMARY KEY NOT NULL,
	CustomerName nvarchar(255) NOT NULL,
	CustomerEmail nvarchar(255) NOT NULL,
	CustomerSalt varbinary(MAX) NOT NULL,
	CustomerPassword varbinary(MAX) NOT NULL,
	CustomerAbilities nvarchar(max) NOT NULL,
);
GO

CREATE TABLE Surveys
(
	SurveysId uniqueidentifier PRIMARY KEY NOT NULL,
	SurveyName nvarchar(255) NOT NULL,
	SurveyDescription nvarchar(max) NOT NULL,
	SurveyStatus bit NOT NULL,
	SurveyUrl nvarchar(50) NOT NULL,
	CustomerId uniqueidentifier FOREIGN KEY REFERENCES Customers(CustomerId)  NOT NULL,

);
GO

CREATE TABLE QuestionTypes
(
	QuestionTypeId uniqueidentifier PRIMARY KEY NOT NULL,
	QuestionTypeName nvarchar(255) NOT NULL,
	QuestionTypeDescription nvarchar(max) NOT NULL,
);
GO

CREATE TABLE Questions
(
	QuestionId uniqueidentifier PRIMARY KEY NOT NULL,
	QuestionName nvarchar(255) NOT NULL,
	QuestionTypeId uniqueidentifier FOREIGN KEY REFERENCES QuestionTypes(QuestionTypeId)  NOT NULL,
	SurveysId uniqueidentifier FOREIGN KEY REFERENCES Surveys(SurveysId)  NOT NULL,
);
GO

CREATE TABLE AnswerVariants
(
	AnswerVariantId uniqueidentifier PRIMARY KEY NOT NULL,
	AnswerVariantName nvarchar(255) NOT NULL,
	QuestionId uniqueidentifier FOREIGN KEY REFERENCES Questions(QuestionId)  NOT NULL,
);
GO

CREATE TABLE Questionnaires
(
	QuestionnairesId uniqueidentifier PRIMARY KEY NOT NULL,
	SurveysId uniqueidentifier FOREIGN KEY REFERENCES Surveys(SurveysId) NOT NULL,
	QuestionId uniqueidentifier FOREIGN KEY REFERENCES Questions(QuestionId) NOT NULL,
	AnswerVariantId uniqueidentifier FOREIGN KEY REFERENCES AnswerVariants(AnswerVariantId)  NOT NULL,
);
GO