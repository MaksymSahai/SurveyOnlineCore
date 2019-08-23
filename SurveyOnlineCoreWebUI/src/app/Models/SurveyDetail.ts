export interface  SurveyDetail{
    SurveysId: string;
    SurveyName: string;
    SurveyDescription: string;
    SurveyStatus: boolean;
    SurveyUrl: string;
    questions: QuestionDetail[];
}

export interface  QuestionDetail{
    QuestionId: string;
    QuestionName: string;
    QuestionTypeId: string;
    answerVariants: AnswerDetail[];
}

export interface  AnswerDetail{
    AnswerVariantId: string;
    AnswerVariantName: string;
}