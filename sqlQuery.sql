--FUNK getAssigned Question
CREATE FUNCTION [dbo].[getAssignedQuestions] (@user_id INT)
RETURNS TABLE
AS
RETURN
	(SELECT question, date
	from users as p, questions as q, questionsAssignedToEachPerson aq
	where @user_id = p.Id and q.Id = aq.FK_quesstionId and p.Id = aq.FK_userId)

--SP ask question to Patient
CREATE PROCEDURE [dbo].[SPaskQuestionToPatient]
	@patientId int,
	@questionId int,
	@date Datetime
AS
	INSERT INTO [dbo].[questionsAssignedToEachPerson] (FK_userId, FK_quesstionId, date) VALUES (@patientId, @questionId, @date)
RETURN 0	
	
--TABLE
CREATE TABLE [dbo].[questionsAssignedToEachPerson] (
    [FK_quesstionId] INT      NOT NULL,
    [FK_userId]      INT      NOT NULL,
    [date]           DATETIME NOT NULL,
    [isAnswered]     BIT      DEFAULT ((0)) NULL,
    CONSTRAINT [PK_assignedQuestionsPerPerson] PRIMARY KEY CLUSTERED ([date] ASC, [FK_quesstionId] ASC, [FK_userId] ASC),
    CONSTRAINT [FK_questionsAssignedToEachPerson_ToTable] FOREIGN KEY ([FK_userId]) REFERENCES [dbo].[users] ([Id]),
    CONSTRAINT [FK_questionsAssignedToEachPerson_ToTable_1] FOREIGN KEY ([FK_quesstionId]) REFERENCES [dbo].[questions] ([Id])
);

--questions
CREATE TABLE [dbo].[questions] (
    [Id]       INT   IDENTITY (1, 1) NOT NULL,
    [question] NTEXT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);




	
--SP asignSensorToPatient
CREATE PROCEDURE [dbo].[SPassignSensorToPatient]
	@patientId int,
	@sensorId int
AS
	INSERT INTO [dbo].[sensorsAssignedToEachPerson] ([userId], [sensorId]) VALUES (@patientId, @sensorId)
RETURN 0
--SP add person
CREATE PROCEDURE [dbo].[SPaddPerson] 
	@name nchar,
	@surname nchar,
	@birthdate datetime
AS 
BEGIN
	INSERT INTO [dbo].[users] (name, surname, birthdate) VALUES (@name, @surname, @birthdate )
END
RETURN 0
--Table CREATE TABLE [dbo].[users] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [name]      NCHAR (10) NULL,
    [surname]   NCHAR (10) NULL,
    [birthdate] DATETIME   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

--sensorsassigned to each patient
CREATE TABLE [dbo].[sensorsAssignedToEachPatient] (
    [patientId] INT NOT NULL,
    [sensorId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([sensorId] ASC, [patientId] ASC),
    CONSTRAINT [FK_sensorsAssignedToEachPatient_ToTable] FOREIGN KEY ([sensorId]) REFERENCES [dbo].[Sensors] ([Id]),
    CONSTRAINT [FK_sensorsAssignedToEachPatient_ToTable_1] FOREIGN KEY ([patientId]) REFERENCES [dbo].[users] ([Id])
);
--sensors
CREATE TABLE [dbo].[Sensors] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL,
    [SensorType] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


