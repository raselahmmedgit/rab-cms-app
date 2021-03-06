USE [CityGlassCompany]
GO
INSERT [dbo].[AspNetRoles] ([Id], [IsActive], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'Admin', 1, N'Admin', N'ADMIN', N'140025ba-2481-48c8-b26e-2f6e0292defb')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Country], [Age], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4b1fc815-ead7-4426-b6db-548d82f3d736', 0, 0, N'admin@mail.com', N'ADMIN@MAIL.COM', N'admin@mail.com', N'ADMIN@MAIL.COM', 0, N'AQAAAAEAACcQAAAAENZ3TncTdBDuG1fsC+Zm+RzikuXhANgB2gXWcDDZ/p1CpPnnOkdK60F68JVoAYvnJw==', N'JOB4HI3MRDFGB2ZAWOYQZMNIQC3BNRGZ', N'069c0c34-2d79-435a-a61e-a7cc47345ba0', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4b1fc815-ead7-4426-b6db-548d82f3d736', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[ContactUsConfig] ON 
GO
INSERT [dbo].[ContactUsConfig] ([Id], [ContactUsConfigType], [ToEmailAddress], [FromEmailAddress], [FromEmailAddressDisplayName], [PhoneNumber], [PhoneNumberDisplayName], [TestEmailAddress], [DisplayOrder]) VALUES (1, N'Main', N'cityglass4@gmail.com', N'cityglass4@gmail.com', N'City Glass - Contact Us', N'', N'City Glass - Contact Us', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[ContactUsConfig] OFF
GO
SET IDENTITY_INSERT [dbo].[EmailSmsConfig] ON 
GO
INSERT [dbo].[EmailSmsConfig] ([Id], [FromEmailAddress], [FromEmailAddressDisplayName], [Password], [Host], [Port], [AllowSsl], [SendGridFromEmailAddress], [SendGridFromEmailAddressDisplayName], [SendGridApiKey], [TestEmailAddress], [SmsFromNumber], [SmsAccountSid], [SmsAuthToken], [AllowSms], [AllowEmail]) VALUES (1, N'cityglass4@gmail.com', N'City Glass', N'apzUpuK4', N'smtp.gmail.com', N'587', 1, N'cityglass4@gmail.com', N'City Glass', N'', N'Rasel Ahmed_rasel@placovu.com', NULL, N'', N'', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[EmailSmsConfig] OFF
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'0d4ba713-238c-41ed-b5b3-1b7dcf0b3bc8', N'Touhid', N'Islam', N'Touhid Islam', N'touhid@placovu.com', N'000000000000', N'000000000', N'000000000', N'000000000', N'0000000', N'00000000000000000', N'000000000000000', N'United States', N'00000', N'00000000', N'0000', NULL, N'0000', N'Yes', N'Yes', N'Yes', NULL, NULL, NULL, N'Yes', N'Yes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Yes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'2f9ac426-e222-415c-ab31-a65cc791b144', N'Test', N'Placovu 1215', N'Test Placovu 1215', N'test@placovu.com', N'0000000000', N'0000000000', N'wer', N'test street 1', N'test street 1', N'minnesota', N'Minnesota - MN', N'United States', N'55441', N'minnesota', N'Minnesota - MN', NULL, N'55441', N'Yes', N'Yes', N'Yes', N'wer', N'23', N'01/29/2021', N'Yes', N'Yes', N'01/29/2021', N'minnesota', N'wr', N'wer', N'wer', N'wer', N'wer', N'wer', N'wer', N'Yes', N'wre', N'wer', N'wre', N'test street 1', N'minnesota', N'Minnesota - MN', N'55441', N'01/29/2021', N'01/30/2021', N'23', N'23', N'dgdfg', N'dfgd', N'dfg', N'test street 1', N'minnesota', N'Minnesota - MN', N'55441', N'01/29/2021', N'00', N'23', N'23', N'sf', N'sdf', N'sdf', N'test street 1', N'minnesota', N'Minnesota - MN', N'55441', N'01/28/2021', N'01/22/2021', N'sdf', N'sdf', N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'3db70d3b-34b1-42a6-9bd8-733520587aab', N'Dushwn', N'Hatley', N'Dushwn Hatley', N'Dushawncurtis@gmail.com', N'3127148878', NULL, NULL, N'3729 Westmeadow drive', N'4913 w erie st', N'Colorado springs', N'Colorado', N'United States', N'80906', N'chicago', N'Illinois', NULL, N'60644', N'Yes', N'Yes', N'Yes', N'open', N'open', N'Apil 2021', N'Yes', N'Yes', NULL, NULL, NULL, N'Proviso East Highschool', N'n/a', N'n/a', NULL, NULL, NULL, N'Yes', N'Sgt Pastorelle', N'Radar operator', N'josephpastorelle@gmail.com', N'2144 utah beach', N'fort carson', N'colorado springs', N'80913', N'September 23,2019', N'April 2021', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'4563dd68-93dd-4da2-ba53-4dbdba78fbac', N'Marlon', N'Serrano', N'Marlon Serrano', N'digadadaddymar@yahoo.com', N'5619292838', NULL, NULL, N'7045 Fountainside Grv', N'9480 Boca Cove Circle apt 409', N'Colorado Springs', N'Colorado', N'United States', N'80922-1255', N'Boca Raton', N'FL', NULL, N'33428', N'Yes', N'Yes', N'Yes', N'Fabricator of Glass Frame', N'negotiable', N'03/29/21', N'Yes', N'Yes', NULL, NULL, NULL, N'Institute Albert Maferer - El Salvador', NULL, NULL, NULL, NULL, N'•	Forklift and heavy equipment operations Safety operate equipment being used.
•	Able to do work under pressure either independent or as a team member.
•	Knows the meaning of teamwork in its real sense.
•	Shipping and Receiving operations.
•	Fabricate aluminum frames from blue prints.
•	The usage of cutting and fold bend machines.
•	Operated tools and equipment operations.
', N'Yes', N'King Soopers', N'produce cleerk', NULL, NULL, N'Colorado Springs', N'CO', N'80922', N'11/2020', N'02/2021', NULL, NULL, N'Harmon', N'Fabricator of Glass frames', NULL, NULL, N'Boynton Beach', N'FL', NULL, N'09/2008', N'04/2009', NULL, NULL, N'Alumiglass', N'Fabricator of Glass Frames', NULL, NULL, N'Boca Raton', N'FL', NULL, N'07/2001', N'07/2007', NULL, NULL, N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'58a0e69a-aa84-4d77-84db-5aeb5ad34f02', N'Test', N'Placovu', N'Test Placovu', N'test@placovu.com', N'12345', N'0000000000', N'wer', N'test street 1', N'test street 1', N'minnesota', N'Minnesota - MN', N'United States', N'55441', N'minnesota', N'Minnesota - MN', NULL, N'55441', N'Yes', N'Yes', N'Yes', N'wer', N'23', N'01/19/2021', N'Yes', N'Yes', N'01/04/2021', N'minnesota', N'werwer', N'wer', N'wer', N'wer', N'wre', N'wer', N'wer', N'Yes', N'wre', N'wer', N'wre', N'test street 1', N'wer', N'wre', N'213', N'01/26/2021', N'01/19/2021', N'23', N'23', N'dgdfg', N'dfgd', N'dfg', N'dfg', N'minnesota', N'Minnesota - MN', N'55441', N'01/13/2021', N'00', N'23', N'23', N'sf', N'sdf', N'sdf', N'test street 1', N'sdf', N'sdf', N'sdf', N'01/29/2021', N'01/06/2021', N'sdf', N'sdf', N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'd1ff267f-fc79-4ceb-9ca6-6b0b2d27d800', N'Debra', N'Miller', N'Debra Miller', N'debiej0656@hotmail.com', N'719-963-2208', NULL, NULL, N'835 Musket Dr, #105', N'1925 Madison St', N'Colorado Springs', N'Colorado', N'United States', N'80905', N'Denver', N'Colorado ', NULL, N'80210', N'Yes', N'Yes', N'Yes', N'Service counter team member', N'between 14-16', N'03/15/2021', N'Yes', N'Yes', NULL, NULL, NULL, N'Newton High School', N'Pikes Peak Comm College', NULL, N'General/Accounting', NULL, N'just english', N'Yes', N'Dollar Tree', N'Cashier', N'n/a', N'1530 S CIrcle Drive', N'Colorado Springs', N'CO', N'80910', N'06/01/2019', N'would like full time work', NULL, NULL, N'Sprint Cell Phone Service', N'Credit Specialist II', N'n/a', N'333 Inverness Drive South', N'Englewood', N'Colorado', N'80112', N'11/07/2011', N'08/11/2014', NULL, NULL, N'Sears Dept Store', N'Cashier', N'n/a', N'7001 S University Blvd', N'Centennial(Denver)', N'Colorado', N'80122', N'11/10/2009', N'11/26/2011', NULL, NULL, N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'dda34938-fdaa-4d52-9cb6-e1006769db48', N'Rasel', N'Ahmmed', N'Rasel Ahmmed', N'rasel@placovu.com', N'7637806699', NULL, NULL, N'9825 Hospital Drive, Maple Grove, MN 55369', NULL, N'Maple Grove', N'Washington', N'United States', N'55369', NULL, NULL, NULL, NULL, N'Yes', N'Yes', N'Yes', NULL, NULL, N'01/28/2021', N'Yes', N'Yes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Yes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'f292cce0-5df9-4c58-95d7-8a8c9de582f7', N'Touhid', N'Islam', N'Touhid Islam', N'touhid@placovu.com', N'qeqweqwe', N'000000000', N'000000000', N'000000000', N'0000000', N'eqweqw', N'qweqwe', N'United States', N'567657', N'00000000', N'0000', NULL, N'0000', N'Yes', N'Yes', N'Yes', NULL, NULL, NULL, N'Yes', N'Yes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Yes', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Employment Agency', NULL, NULL)
GO
INSERT [dbo].[EmploymentApplication] ([Id], [FirstName], [LastName], [DisplayName], [EmailAddress], [PhoneNumber], [SecondaryPhoneNumber], [ReferredBy], [PresentAddress], [LastAddress], [City], [State], [Country], [ZipCode], [LastCity], [LastState], [LastCountry], [LastZipCode], [LegalInUSA], [CurrentlyEmployed], [CanContactYouEmployer], [CurrentlyEmploymentPosition], [SalaryDesired], [StartDate], [ApplyBefore], [WorkBefore], [JoinDate], [LastSupervisorName], [ReasonForLeave], [HighSchoolName], [CollegeName], [TradeBusinessSchoolName], [SpecialStudyResearchWork], [SpecialTrainingCertificationsLicenses], [SpecialSkillsLanguages], [MilitaryServiceRecord], [LastEmployerNameOne], [LastEmployerJobTitleOne], [LastEmployerEmailAddressOne], [LastEmployerAddressOne], [LastEmployerCityOne], [LastEmployerStateOne], [LastEmployerZipCodeOne], [LastEmployerStartDateOne], [LastEmployerLeaveDateOne], [LastEmployerWeeklyStartSalaryOne], [LastEmployerWeeklyFinalSalaryOne], [LastEmployerNameTwo], [LastEmployerJobTitleTwo], [LastEmployerEmailAddressTwo], [LastEmployerAddressTwo], [LastEmployerCityTwo], [LastEmployerStateTwo], [LastEmployerZipCodeTwo], [LastEmployerStartDateTwo], [LastEmployerLeaveDateTwo], [LastEmployerWeeklyStartSalaryTwo], [LastEmployerWeeklyFinalSalaryTwo], [LastEmployerNameThree], [LastEmployerJobTitleThree], [LastEmployerEmailAddressThree], [LastEmployerAddressThree], [LastEmployerCityThree], [LastEmployerStateThree], [LastEmployerZipCodeThree], [LastEmployerStartDateThree], [LastEmployerLeaveDateThree], [LastEmployerWeeklyStartSalaryThree], [LastEmployerWeeklyFinalSalaryThree], [KnowAboutThisPosition], [IsArchived], [IsDeleted]) VALUES (N'f3373022-3c4b-4fd6-a1e2-9602c7b71947', N'Test', N'Placovu werwer', N'Test Placovu werwer', N'test@placovu.com', N'0000000000', N'0000000000', N'wer', N'test street 1', N'test street 1', N'minnesota', N'Minnesota - MN', N'United States', N'55441', N'minnesota', N'Minnesota - MN', NULL, N'55441', N'Yes', N'Yes', N'Yes', N'wer', N'23', N'01/05/2021', N'Yes', N'Yes', N'01/21/2021', N'minnesota', N'sadf', N'asdf', N'afd', N'wer', N'sdf', N'adf', N'asdf', N'Yes', N'wre', N'wer', N'wre', N'test street 1', N'minnesota', N'Minnesota - MN', N'55441', N'01/19/2021', N'01/26/2021', N'23', N'23', N'dgdfg', N'dfgd', N'dfg', N'test street 1', N'minnesota', N'Minnesota - MN', N'55441', N'01/14/2021', N'00', N'23', N'23', N'sf', N'sdf', N'sdf', N'test street 1', N'minnesota', N'Minnesota - MN', N'55441', N'01/27/2021', N'01/27/2021', N'sdf', N'sdf', N'Employment Agency', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Media] ON 
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (1, N'city_glass_video_cover.jpg', N'upload/2021/4/city_glass_video_cover.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (2, N'city_glass_final_compressed.mp4', N'upload/2021/4/city_glass_final_compressed.mp4', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (3, N'commertial_1.jpg', N'upload/2021/4/commertial_1.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (4, N'Feature-Section.jpg', N'upload/2021/4/Feature-Section.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (5, N'Feature-Section_back.png', N'upload/2021/4/Feature-Section_back.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (6, N'Residentials_1.jpg', N'upload/2021/4/Residentials_1.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (7, N'Subscribe.png', N'upload/2021/4/Subscribe.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (8, N'bbb_logo.png', N'upload/2021/4/bbb_logo.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (9, N'doors-windows.jpg', N'upload/2021/4/doors-windows.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (10, N'glass-company-truck.jpg', N'upload/2021/4/glass-company-truck.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (11, N'screen-repair007.jpg', N'upload/2021/4/screen-repair007.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (12, N'shower-enclosure.jpg', N'upload/2021/4/shower-enclosure.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (13, N'table-glass.png', N'upload/2021/4/table-glass.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (14, N'glass-cabinet-inserts-angle001.jpg', N'upload/2021/4/glass-cabinet-inserts-angle001.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (15, N'glass-cabinet-inserts-front001.jpg', N'upload/2021/4/glass-cabinet-inserts-front001.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (16, N'glass-shelves.jpg', N'upload/2021/4/glass-shelves.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (17, N'iStock-182247682.jpg', N'upload/2021/4/iStock-182247682.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (18, N'iStock-183289827.jpg', N'upload/2021/4/iStock-183289827.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (19, N'iStock-1216233882.jpg', N'upload/2021/4/iStock-1216233882.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (20, N'iStock-1227208602.jpg', N'upload/2021/4/iStock-1227208602.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (21, N'panel-glass.png', N'upload/2021/4/panel-glass.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (22, N'2016-Hartung-TVS-01-web.pdf', N'upload/2021/4/2016-Hartung-TVS-01-web.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (23, N'2016-10-Agalite-Transcend.pdf', N'upload/2021/4/2016-10-Agalite-Transcend.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (24, N'EasyClean10-Brochure.pdf', N'upload/2021/4/EasyClean10-Brochure.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (25, N'Napa-90-Flyer-no-price-page-link.pdf', N'upload/2021/4/Napa-90-Flyer-no-price-page-link.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (26, N'screen-repair011.jpg', N'upload/2021/4/screen-repair011.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (27, N'screen-repair013.jpg', N'upload/2021/4/screen-repair013.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (28, N'contact-header.jpg', N'upload/2021/4/contact-header.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-09T03:48:28.370' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (29, N'doors-hardware532.jpg', N'upload/2021/4/doors-hardware532.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (30, N'doors-hardware173.jpg', N'upload/2021/4/doors-hardware173.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (31, N'board-up-services-repair.jpg', N'upload/2021/4/board-up-services-repair.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (32, N'board-up-services-626.jpg', N'upload/2021/4/board-up-services-626.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (33, N'door-header.jpg', N'upload/2021/4/door-header.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (34, N'store_front_one.jpg', N'upload/2021/4/store_front_one.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (35, N'store_front_two.jpg', N'upload/2021/4/store_front_two.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (36, N'store_front_three.jpg', N'upload/2021/4/store_front_three.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (37, N'curtain-wall-one.jpg', N'upload/2021/4/curtain-wall-one.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (38, N'curtain-wall-two.jpg', N'upload/2021/4/curtain-wall-two.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (39, N'curtain-wall-three.jpg', N'upload/2021/4/curtain-wall-three.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (40, N'doors-one.jpg', N'upload/2021/4/doors-one.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (41, N'door-two.jpg', N'upload/2021/4/door-two.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (42, N'door-three.jpg', N'upload/2021/4/door-three.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (43, N'new-construction001.jpg', N'upload/2021/4/new-construction001.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (44, N'board-up-services-commercial.jpg', N'upload/2021/4/board-up-services-commercial.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (45, N'commercial-windows-005.jpg', N'upload/2021/4/commercial-windows-005.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (46, N'iStock-1147286219.jpg', N'upload/2021/4/iStock-1147286219.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (47, N'emergency-glass-service001.jpg', N'upload/2021/4/emergency-glass-service001.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (48, N'board-up-services.jpg', N'upload/2021/4/board-up-services.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (49, N'window-door-slider-one.jpg', N'upload/2021/4/window-door-slider-one.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (50, N'window-door-slider-two.jpg', N'upload/2021/4/window-door-slider-two.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (51, N'window-door-slider-three.jpg', N'upload/2021/4/window-door-slider-three.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (52, N'window-door-slider-four.jpg', N'upload/2021/4/window-door-slider-four.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (53, N'window-door-slider-five.jpg', N'upload/2021/4/window-door-slider-five.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (54, N'res-door-slider-one.jpg', N'upload/2021/4/res-door-slider-one.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (55, N'res-door-slider-two.jpg', N'upload/2021/4/res-door-slider-two.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (56, N'res-door-slider-three.jpg', N'upload/2021/4/res-door-slider-three.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (57, N'res-door-slider-four.jpg', N'upload/2021/4/res-door-slider-four.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (58, N'document.png', N'upload/2021/4/logo/document.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (59, N'DaylightMax-Brochure.pdf', N'upload/2021/4/DaylightMax-Brochure.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (60, N'Simonton-West-Region-Warranty.pdf', N'upload/2021/4/Simonton-West-Region-Warranty.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (61, N'West-Patio-Door-Brochure.pdf', N'upload/2021/4/West-Patio-Door-Brochure.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (62, N'Madeira-Brochure.pdf', N'upload/2021/4/Madeira-Brochure.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (63, N'Verona-Flier.pdf', N'upload/2021/4/Verona-Flier.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (64, N'Verona-Simonton-Warranty.pdf', N'upload/2021/4/Verona-Simonton-Warranty.pdf', NULL, NULL, NULL, NULL, CAST(N'2021-04-08T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (65, N'common-header.png', N'upload/2021/4/common-header.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (66, N'board-up-services-624.jpg', N'upload/2021/4/board-up-services-624.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (67, N'City-Glass-Company.png', N'upload/2021/4/City-Glass-Company.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (68, N'city-glass-company-old-chicago03.jpg', N'upload/2021/4/city-glass-company-old-chicago03.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (69, N'City-Logo-Round.png', N'upload/2021/4/City-Logo-Round.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (70, N'Double-Hung-Windows.jpg', N'upload/2021/4/Double-Hung-Windows.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (71, N'glass-shelves003.jpg', N'upload/2021/4/glass-shelves003.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (72, N'IMG_1442.jpeg', N'upload/2021/4/IMG_1442.jpeg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (73, N'IMG_1442.jpg', N'upload/2021/4/IMG_1442.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (74, N'iStock-183289827.jpg', N'upload/2021/4/iStock-183289827.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (75, N'iStock-525964080.jpg', N'upload/2021/4/iStock-525964080.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (76, N'Our-History.png', N'upload/2021/4/Our-History.png', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (77, N'Project-Gallery.jpg', N'upload/2021/4/Project-Gallery.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (78, N'shower-enclosure003.jpg', N'upload/2021/4/shower-enclosure003.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
INSERT [dbo].[Media] ([Id], [Name], [Url], [Title], [Alt], [Description], [ParentId], [AddedOn]) VALUES (79, N'tub-glass-enclosure003.jpg', N'upload/2021/4/tub-glass-enclosure003.jpg', NULL, NULL, NULL, NULL, CAST(N'2021-04-07T14:05:55.430' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Media] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 
GO
INSERT [dbo].[Menu] ([Id], [Name], [Item], [AddedOn], [Status]) VALUES (1, N'Main', N'[{"deleted":0,"new":1,"slug":"residential","name":"Residential","id":"new-1","children":[{"deleted":0,"new":1,"slug":"flat-glass-plastics","name":"Flat Glass & Plastics","id":"new-1"},{"deleted":0,"new":1,"slug":"mirrors-shower-doors","name":"Mirrors & Shower Doors","id":"new-2"},{"deleted":0,"new":1,"slug":"screens","name":"Screens","id":"new-3"},{"deleted":0,"new":1,"slug":"windows-doors","name":"Windows & Doors","id":"new-4"},{"deleted":0,"new":1,"slug":"services","name":"Services","id":"new-5"}]},{"deleted":0,"new":1,"slug":"commercial","name":"Commercial","id":"new-6","children":[{"deleted":0,"new":1,"slug":"new-construction","name":"New Construction","id":"new-7"},{"deleted":0,"new":1,"slug":"repair-replace","name":"Repair & Replace","id":"new-8"},{"deleted":0,"new":1,"slug":"services","name":"Services","id":"new-15"}]},{"deleted":0,"new":1,"slug":"about","name":"About","id":"new-9","children":[{"deleted":0,"new":1,"slug":"about#our-company","name":"Our Company","id":"new-10"},{"deleted":0,"new":1,"slug":"about#career-employment","name":"Career Employment","id":"new-11"},{"deleted":0,"new":1,"slug":"about#news-video","name":"News/Videos","id":"new-12"},{"deleted":0,"new":1,"slug":"about#faq","name":"FAQ","id":"new-13"}]},{"deleted":0,"new":1,"slug":"contact","name":"Contact","id":"new-14"}]', CAST(N'2021-04-02T10:59:39.977' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Page] ON 
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (1, N'Home', N'home', N'City Glass Company Colorado Springs - Glass Repair & Installation', NULL, 'City Glass Company in Colorado Springs has been serving the Pikes Peak Region since 1950. Call now to receive a free quote on glass repair and installation.', N'<main id="main">
<section class="home-video-section">
<div class="row">
<div class="col-lg-12">
<video class="lazy full-width" controls="" loop="" playsinline="" poster="upload/2021/4/city_glass_video_cover.jpg" preload="none"><data-src src="upload/2021/4/city_glass_final_compressed.mp4" type="video/mp4"></data-src></video>

<div class="video-playpause">&nbsp;</div>
</div>
</div>
</section>

<section>
<div class="container">
<div class="row">
<div class="col-12 pb-2">
<div class="d-flex flex-wrap container p-2 justify-content-center" data-aos="fade-up">
<h1 class="pb-3 text-center"><span>Colorado Springs most reliable glass company </span> <span> for mirrors, showers, windows, storefronts and more! </span></h1>
</div>
</div>
</div>

<div class="row">
<div class="col-12">
<div class="card-deck">
<div class="card no-border" data-aos="fade-right"><img class="lazy card-img-top" data-src="upload/2021/4/Residentials_1.jpg" />
<div class="card-body bg-gray">
<div class="row">
<div class="col-12 pt-3 pb-3"><a class="link-btn btn-yellow-xl btn-block" href="/residential">Residential</a></div>
</div>

<div class="card-text">City Glass Company provides home glass repair and many other services to ensure you have the look and feel that you want in the place you call home.</div>
</div>
</div>

<div class="card no-border" data-aos="fade-left"><img class="lazy card-img-top" data-src="upload/2021/4/commertial_1.jpg" />
<div class="card-body bg-gray">
<div class="row">
<div class="col-12 pt-3 pb-3"><a class="link-btn btn-yellow-xl btn-block" href="/Commercial">Commercial</a></div>
</div>

<div class="card-text">Area business owners trust City Glass to execute their glass and mirror installations on time, on budget, and with excellent results.</div>
</div>
</div>
</div>
</div>
</div>
</div>
</section>

<section class="skills" id="skills">
<div class="container" data-aos="fade-up">
<div class="section-title mb-3">
<h2 class="mb-0">Feature</h2>
</div>

<div class="row">
<div class="col-lg-6 d-flex aos-init aos-animate" data-aos="fade-right" data-aos-delay="200">
<div class="hero-img py-3"><img class="lazy img-fluid" data-src="upload/2021/4/Feature-Section.jpg" /></div>
</div>

<div class="col-lg-6  py-2 content aos-init aos-animate" data-aos="fade-left" data-aos-delay="200">
<div class="card-title">Shower Enclosures</div>

<hr />
<div class="card-text">Shower enclosures are a speciality at City Glass. Trusted by many of the home builders in the Pikes Peak Region, we can transform your home to have a modernized &amp; updated look to your bathrooms. Our estimators will provide a complimentary quote and consultation on what product works best for your decor and your budget.</div>

<div class="row">
<div class="col-12 pt-3"><a class="link-btn btn-yellow-xl" href="/mirrors-shower-doors">Learn More</a></div>
</div>
</div>
</div>
</div>
</section>

<section class="testimonials" id="testimonials">
<div class="container aos-init aos-animate" data-aos="zoom-in">
<div class="owl-carousel testimonials-carousel owl-loaded owl-drag">
<div class="owl-stage-outer">
<div class="owl-stage" style="transform: translate3d(-4440px, 0px, 0px); transition: all 0.25s ease 0s; width: 12210px;">
<div class="owl-item">
<div class="testimonial-item">
<p><span style="font-family: roboto; font-size: 35px; font-weight: 400; color: black; text-align: center;">Very authentic source of all types of glass.</span></p>

<h2 style="font-family: roboto; font-size: 35px; font-weight: 400; color: black; text-align: center;">Rab</h2>

<p>&nbsp;</p>
</div>
</div>

<div class="owl-item">
<div class="testimonial-item">
<p><span style="font-family: roboto; font-size: 35px; font-weight: 400; color: black; text-align: center;">Great company&hellip; on time with delivery and very trustworthy!</span></p>

<h2 style="font-family: roboto; font-size: 35px; font-weight: 400; color: black; text-align: center;">Carol Buck</h2>

<p>&nbsp;</p>
</div>
</div>
</div>
</div>
</div>
</div>
</section>

<section class="bg-light youtube-subscribe-section">
<div class="container">
<div class="row">
<div class="col-12">
<div class="d-flex flex-row p-2 justify-content-center" data-aos="fade-up">
<h3 class="pb-3 text-center">Subscribe to our YouTube channel</h3>
</div>
</div>

<div class="col-12 d-flex -2 justify-content-center"><a href="https://www.youtube.com/channel/UCfwZn0-eGe72Aj96cnfg9mw" target="_blank"><img alt="" class="lazy img-fluid wf-500" data-src="upload/2021/4/Subscribe.png" title="" /> </a></div>
</div>
</div>
</section>

<section class="contact" id="contact">
<div class="container aos-init aos-animate" data-aos="fade-up">
<div class="section-title">
<h2>Showroom</h2>
</div>

<div class="section-info">
<p>Hours: Monday &ndash; Friday 8 a.m. &ndash; 5 p.m.</p>

<p>Parking is available off of Colorado Ave, West of the Colorado Avenue entrance and from the North side of the building off of Spruce Street.</p>

<p class="m-0">414 West Colorado Avenue</p>

<p>Colorado Springs, CO 80905</p>
</div>

<div><iframe allowfullscreen="" class="lazy" data-src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3107.9758087678056!2d-104.83560218529229!3d38.83301485834294!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x871345255b64f729%3A0x6e8c72a1adc4ea3f!2sCity%20Glass%20Company!5e0!3m2!1sen!2s!4v1582566439424!5m2!1sen!2s" frameborder="0" style="border:0; width: 100%; height: 270px;"></iframe></div>
</div>
</section>

<section class="bg-primary p-0 hpx-100">
<div class="container">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="upload/2021/4/bbb_logo.png" /> </a></div>
</div>
</div>
</section>

<section class="bg-gray" id="contactuslink">
<div class="container p-2">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
</div>
</div>
</section>
</main>', CAST(N'2021-04-02T10:59:17.277' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (2, N'Residential', N'residential', N'Colorado Springs Glass Repair - Replacement Windows & Doors', NULL, 'City Glass Company specializes in Colorado Springs glass repair and installation services. Visit our website to browse our selection of replacement windows and doors.', N'<!-- ======= Header ======= -->
<section class="d-flex align-items-center header-common header-residential">
<div class="container">
<div class="row">
<div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column" data-aos="fade-up" data-aos-delay="200">
<h1 class="text-center">Residential</h1>
</div>
</div>
</div>
</section>
<!-- End Header --><main id="main"> <!-- ======= Header Description Section ======= -->
<section class="header-common-des">
<div class="container" data-aos="fade-up">
<div class="row content">
<div class="col-xl-12 col-lg-12 col-md-12">
<p>City Glass Company provides home glass repair, mirrors, shower enclosures, and many other services to ensure you have the look and feel that you want in your home.</p>
</div>
</div>
</div>
</section>
<!-- End Header Description Section -->

<div class="container">
<hr class="hr-divide" /></div>
<!-- ======= Flat Glass & Plastics Section ======= -->

<section id="flat-glass-plastics">
<div class="container" data-aos="fade-up">
<div class="row content">
<div class="col-xl-6 col-lg-6 col-md-6 d-flex" data-aos="fade-right" data-aos-delay="100">
<div class="hero-img"><img alt="" class="lazy img-fluid" data-src="upload/2021/4/table-glass.png" /></div>
</div>

<div class="col-xl-6 col-lg-6 col-md-6 pt-4 pt-lg-0" data-aos="fade-left" data-aos-delay="100">
<div class="section-title">
<h2>Flat Glass &amp; Plastics</h2>
</div>

<div class="section-text">
<p class="text-justify">Transform your home with custom table glass and shelves. City Glass Company&rsquo;s glaziers artfully design glass for tables and shelves, available in a wide variety of styles.</p>

<p class="text-justify">Plexiglass is a wonderful alternative to traditional glass in some home situations. When you want shatterproof clear views in high traffic locations, it could be your best solution.</p>
</div>

<div class="section-link"><a class="link-btn btn-yellow-xl" href="/flat-glass-plastics"><span class="link-btn-label">Learn More</span></a></div>
</div>
</div>
</div>
</section>
<!-- End Flat Glass & Plastics Section -->

<div class="container">
<hr class="hr-divide" /></div>
<!-- ======= Mirrors & Shower Doors Section ======= -->

<section id="mirrors-shower-doors">
<div class="container" data-aos="fade-up">
<div class="row content">
<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12  pt-4 pt-lg-0 order-1" data-aos="fade-left" data-aos-delay="100">
<div class="section-title">
<h2>Mirrors &amp; Shower Doors</h2>
</div>

<div class="section-text">
<p class="text-justify">City Glass Company is one of the most trusted names in the business when someone needs a mirror or shower door. Whether your home is big or small, 10 or 100 years old, urban or rural&hellip;</p>
</div>

<div class="section-link"><a class="link-btn btn-yellow-xl" href="/mirrors-shower-doors"><span class="link-btn-label">Learn More</span></a></div>
</div>

<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex order-0" data-aos="fade-right" data-aos-delay="100">
<div class="hero-img"><img alt="" class="lazy img-fluid" data-src="upload/2021/4/shower-enclosure.jpg" /></div>
</div>
</div>
</div>
</section>
<!-- End Mirrors & Shower Doors Section -->

<div class="container">
<hr class="hr-divide" /></div>
<!-- ======= Windows & Doors Section ======= -->

<section id="windows-doors">
<div class="container" data-aos="fade-up">
<div class="row content">
<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex" data-aos="fade-right" data-aos-delay="100">
<div class="hero-img"><img alt="" class="lazy img-fluid" data-src="upload/2021/4/doors-windows.jpg" /></div>
</div>

<div class="col-xl-6 col-lg-6 col-md-6 pt-4 pt-lg-0" data-aos="fade-left" data-aos-delay="100">
<div class="section-title">
<h2>Windows &amp; Doors</h2>
</div>

<div class="section-text">
<p class="text-justify">Quality windows and doors add value, protection, and energy efficiency to your home. With a wide range of styles and materials, City Glass Company provides Colorado Springs&rsquo; finest windows and doors installation, replacement, and design.</p>
</div>

<div class="section-link"><a class="link-btn btn-yellow-xl" href="/windows-doors"><span class="link-btn-label">Learn More</span></a></div>
</div>
</div>
</div>
</section>
<!-- End Windows & Doors Section -->

<div class="container">
<hr class="hr-divide" /></div>
<!-- ======= Screens Section ======= -->

<section id="screens">
<div class="container" data-aos="fade-up">
<div class="row content">
<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 pt-lg-0 order-1" data-aos="fade-right" data-aos-delay="100">
<div class="section-title">
<h2>Screens</h2>
</div>

<div class="section-text">
<p class="text-justify">While you probably know City Glass is expert in glass door and window repair, we also repair and replace window and door screens. We&rsquo;ll repair tears in your window or door screens and if necessary replace and install new ones. Our screens come in a variety of materials and designs to meet your specifications. And you may be pleasantly surprised to discover how economical screen replacement is!</p>
</div>

<div class="section-link"><a class="link-btn btn-yellow-xl" href="/screens"><span class="link-btn-label">Learn More</span></a></div>
</div>

<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex order-0" data-aos="fade-left" data-aos-delay="100">
<div class="hero-img"><img alt="" class="lazy img-fluid" data-src="upload/2021/4/screen-repair007.jpg" /></div>
</div>
</div>
</div>
</section>
<!-- End Screens Section -->

<div class="container">
<hr class="hr-divide" /></div>
<!-- ======= Services Section ======= -->

<section id="services">
<div class="container" data-aos="fade-up">
<div class="row content">
<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex" data-aos="fade-right" data-aos-delay="100">
<div class="hero-img"><img alt="" class="lazy img-fluid" data-src="upload/2021/4/glass-company-truck.jpg" /></div>
</div>

<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 pt-4 pt-lg-0" data-aos="fade-left" data-aos-delay="100">
<div class="section-title">
<h2>Services</h2>
</div>

<div class="section-text">
<p class="text-justify">Our glass services are perfect for homeowners, property managers and store owners. If your home or business is in need of emergency glass service or maintenance, we&rsquo;ll make sure your property is safe, secured and repaired as soon as possible.</p>
</div>

<div class="section-link"><a class="link-btn btn-yellow-xl" href="/services"><span class="link-btn-label">Learn More</span></a></div>
</div>
</div>
</div>
</section>
<!-- End Services Section --> </main>

<p>&nbsp;</p>
<section class="bg-primary p-0 hpx-100">
<div class="container">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="upload/2021/4/bbb_logo.png" /> </a></div>
</div>
</div>
</section>

<section class="bg-gray" id="contactuslink">
<div class="container p-2">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
</div>
</div>
</section>', CAST(N'2021-04-02T11:04:36.910' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (3, N'Flat Glass & Plastics', N'flat-glass-plastics', N'Custom Glass Shelves Colorado Springs - Glass Door Cabinets', NULL, 'Create your own custom glass shelves and glass door cabinets at an affordable price with City Glass Company in Colorado Springs. Call now to receive a free estimate.', N'<section class="d-flex align-items-center header-common header-common-img flatglassplastic-img">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column" data-aos="fade-up" data-aos-delay="200">
                <h1 class="text-center">Flat Glass & Plastics</h1>
            </div>
        </div>
    </div>
</section><!-- End Header -->

<main id="main">
    <!-- ======= Header Description Section ======= -->
    <section class="header-common-des">
        <div class="container" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h5>
                        Customize your table glass or shelving with our variety of glass, Plexiglass, and finish options. Choose from clear, tinted, textured, reflective, frosted glass and more. City Glass Company also offers the region’s finest glass etching to further enhance your project’s design.
                    </h5>
                </div>
            </div>
        </div>
    </section><!-- End Header Description Section --> 
    <div class="container">
        <hr class="hr-divide" />
    </div>
    <!-- ======= 1 Section ======= -->
    <section id="flat-glass-plastics-section-1" class="slider-section">
        <div class="container" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-12 d-flex mb-3" data-aos="fade-right" data-aos-delay="100">
                    <div class="slider-box mr-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_one" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_one" data-slide-to="0" class="active"></li>
                                        <li data-target="#slider_one" data-slide-to="1" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="owl-lazy carousel-item active" style="background-image: url(upload/2021/4/iStock-183289827.jpg)">

                                        </div>
                                        <!-- Slide 2 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(upload/2021/4/table-glass.png)">

                                        </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_one" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_one" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Tabletops</h2>
                        </div>
                        <div class="slider-box-content">
                            <p class="text-justify">
                                A creative and elegantly designed glass table can improve the look of any room in your home. Not only do glass tables brighten a room, they are extremely versatile in style. Consider a custom table for your ultra–modern kitchen or consult our glass etching experts to create a classically decorative glass dining table.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12 d-flex mb-3" data-aos="fade-left" data-aos-delay="100">
                    <div class="slider-box ml-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_two" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_two" data-slide-to="0" class="active"></li>
                                        <li data-target="#slider_two" data-slide-to="1" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="carousel-item active" style="background-image: url(upload/2021/4/glass-shelves.jpg)">

                                        </div>
                                        <!-- Slide 2 -->
                                        <div class="carousel-item" style="background-image: url(upload/2021/4/iStock-182247682.jpg)">

                                        </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_two" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_two" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Shelving</h2>
                        </div>
                        <div class="slider-box-content text-justify">
                            <p class="text-justify">
                                Customize your shelving with our variety of glass and finish options. Choose from clear, tinted, textured, reflective, frosted glass and more. City Glass Company also offers the region’s finest glass etching to further enhance your project’s design.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-12  mb-3 d-flex" data-aos="fade-right" data-aos-delay="100">
                    <div class="slider-box mr-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_three" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_three" data-slide-to="0" class="active"></li>
                                        <li data-target="#slider_three" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_three" data-slide-to="2" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="carousel-item active" style="background-image: url(upload/2021/4/panel-glass.png)">

                                        </div>
                                        <!-- Slide 2 -->
                                        <div class="carousel-item" style="background-image: url(upload/2021/4/glass-cabinet-inserts-front001.jpg)">

                                        </div>
                                        <!-- Slide 3 -->
                                        <div class="carousel-item" style="background-image: url(upload/2021/4/glass-cabinet-inserts-angle001.jpg)">

                                        </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_three" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_three" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Cabinets</h2>
                        </div>
                        <div class="slider-box-content">
                            <p class="text-justify">
                                City Glass Company has access to an excellent variety of clear, tinted, or decorative glass panels for installation in most cabinets. We provide glass panels in homes and businesses throughout the Colorado Springs area, custom designing cabinet glass panels for kitchens, bathrooms, offices and more.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12  mb-3 d-flex" data-aos="fade-left" data-aos-delay="100">
                    <div class="slider-box ml-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_four" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_four" data-slide-to="0" class="active"></li>
                                        <li data-target="#slider_four" data-slide-to="1" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="carousel-item active" style="background-image: url(upload/2021/4/iStock-1216233882.jpg)">

                                        </div>
                                        <!-- Slide 2 -->
                                        <div class="carousel-item" style="background-image: url(upload/2021/4/iStock-1227208602.jpg)">

                                        </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_four" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_four" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Plastics</h2>
                        </div>
                        <div class="slider-box-content">
                            <p class="text-justify">
                                Strong, beautiful, and affordable, Plexiglass gives the beauty of glass without breakage. Plexiglass has many advantages over regular glass for some specific purposes.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- 1 Section -->


</main><!-- End #main -->
<section class="bg-primary p-0 hpx-100">
<div class="container">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="upload/2021/4/bbb_logo.png" /> </a></div>
</div>
</div>
</section>

<section class="bg-gray" id="contactuslink">
<div class="container p-2">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
</div>
</div>
</section>', CAST(N'2021-04-02T11:05:29.153' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (4, N'Mirrors & Shower Doors', N'mirrors-shower-doors', N'Shower Doors Colorado Springs - Glass Shower Installation', NULL, 'When you need new shower doors in Colorado Springs, you can count on City Glass Company. Call now to request a free quote on custom glass shower installation.', N'<!-- ======= Header ======= -->
<section class="d-flex align-items-center header-common header-common-img header-mirrors-shower-doors">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column" data-aos="fade-up" data-aos-delay="200">
                <h1 class="text-center">Mirrors & Shower Doors</h1>
            </div>
        </div>
    </div>
</section><!-- End Header -->

<main id="main">
    <!-- ======= Header Description Section ======= -->
    <section class="header-common-des about">
        <div class="container" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h5>
                        City Glass Company is one of the most trusted names in the business when someone needs a new shower enclosure or mirror applications. Whether your home is big or small, 10 or 100 years old, urban or rural…let us create your dream shower enclosure!
                    </h5>
                </div>
                <div class="pt-3 col-12 d-flex justify-content-center align-items-center">
                    <a class="link-btn btn-yellow-xl" href="#brochures">
                        <span class="link-btn-label">Click here for Brochures</span>
                    </a>
                </div>
            </div>
        </div>
    </section><!-- End Header Description Section -->
   
    <div class="container">
        <hr class="hr-divide" />
    </div>
    <!-- ======= 1 Section ======= -->
    <section id="mirrors-shower-doors-section-1" class="slider-section">
        <div class="container" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex" data-aos="fade-right" data-aos-delay="100">
                    <div class="slider-box mr-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_one" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_one" data-slide-to="0" class="active"></li>
                                        <li data-target="#slider_one" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_one" data-slide-to="2" class=""></li>
                                        <li data-target="#slider_one" data-slide-to="3" class=""></li>
                                        <li data-target="#slider_one" data-slide-to="4" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="owl-lazy carousel-item active" style="background-image: url(upload/2021/4/mirrors-slider-one.jpg)"></div>

                                        <!-- Slide 2 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(upload/2021/4/mirrors-slider-two.jpg)"></div>
                                        <div class="owl-lazy carousel-item" style="background-image: url(upload/2021/4/mirrors-slider-three.jpg)"></div>
                                        <div class="owl-lazy carousel-item" style="background-image: url(upload/2021/4/mirrors-slider-four.jpg)"></div>
                                        <div class="owl-lazy carousel-item" style="background-image: url(upload/2021/4/mirrors-slider-five.jpg)"></div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_one" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_one" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Mirrors</h2>
                        </div>
                        <div class="slider-box-content">
                            <p>
                                City Glass helps put the finishing touch on your dream space with an exquisite mirror to reflect your distinguished style. Mirrors bring visual interest and add radiance to a space. Our glaziers help customers express themselves with our carefully curated selection of mirrors. They are designed to add an elevated touch of sophistication to every room.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex" data-aos="fade-left" data-aos-delay="100">
                    <div class="slider-box ml-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_two" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_two" data-slide-to="0" class="active"></li>
                                        <li data-target="#slider_two" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="2" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="3" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">

                                        <!-- Slide 2 -->
                                        <div class="carousel-item active" style="background-image: url(upload/2021/4/shower-door-slider-one.jpg)"></div>
                                        <!-- Slide 3 -->
                                        <div class="carousel-item" style="background-image: url(upload/2021/4/shower-door-slider-two.jpg)"></div>
                                        <!-- Slide 4 -->
                                        <div class="carousel-item" style="background-image: url(upload/2021/4/shower-door-slider-three.jpg)"></div>
                                        <div class="carousel-item" style="background-image: url(upload/2021/4/shower-door-slider-four.jpg)"></div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_two" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_two" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Shower Doors</h2>
                        </div>
                        <div class="slider-box-content">
                            <p>
                                Our glaziers have installed thousands of shower enclosures throughout Colorado Springs.
                            </p>
                            <p>
                                Select the shower door style and design that’s perfect for you. We’ll fabricate and install the door to your specifications. Regardless of the size or complexity of your project, we’ll create the shower or tub enclosure of your dreams.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- 1 Section -->
    <section id="brochures" class="pt-0">
        <div class="container" data-aos="fade-up">
            <div class="row">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h4 style="font-size: 1.75rem;">
                        Brochures
                    </h4>
                    <h5>
                        See below for the full selection of brochures!
                    </h5> 
                    <hr class="hr-divide" />
                </div>
               
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <ul class="doc-list">
						<li>
							<img class="pdf-icon" src="/site/img/document.png" alt="">
							<a href="upload/2021/4/2021-01-AgaliteCatalogue_MM.6018-010121-webview.pdf" title="https://www.cityglasscompany.net/upload/2021/4/2021-01-AgaliteCatalogue_MM.6018-010121-webview.pdf" target="blank">Agalite Flagship Brochure - All Collections with NEW Napa</a>
							<span class="acf-desc">MM.6018</span>
						</li>
						<li>
                            <img class="pdf-icon" src="/site/img/document.png" alt="">
							<a href="upload/2021/4/Napa-90-Flyer-no-price-page-link.pdf" title="https://www.cityglasscompany.net/upload/2021/4/Napa-90-Flyer-no-price-page-link.pdf" target="blank">NEW - Napa Collection introduction flyer</a>
							<span class="acf-desc">MM.6109</span>
						</li>
					    <li>
                            <img class="pdf-icon" src="/site/img/document.png" alt="">
                            <a href="upload/2021/4/2016-10-Agalite-Transcend.pdf" title="https://www.cityglasscompany.net/upload/2021/4/2016-10-Agalite-Transcend.pdf" target="blank">Agalite Transcend Brochure</a>
							<span class="acf-desc"></span>
						</li>
					    <li>
                            <img class="pdf-icon" src="/site/img/document.png" alt="">
							<a href="upload/2021/4/EasyClean10-Brochure.pdf" title="https://www.cityglasscompany.net/upload/2021/4/EasyClean10-Brochure.pdf" target="blank">Agalite EasyClean10 Brochure</a>
							<span class="acf-desc">MM.6015</span>
						</li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
</main><!-- End #main -->
<section class="bg-primary p-0 hpx-100">
<div class="container">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="upload/2021/4/bbb_logo.png" /> </a></div>
</div>
</div>
</section>

<section class="bg-gray" id="contactuslink">
<div class="container p-2">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
</div>
</div>
</section>', CAST(N'2021-04-02T12:38:57.507' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (5, N'Screens', N'screens', N'Window Screen Repair Colorado Springs - Window Screen Replacement', NULL, 'City Glass Company offers affordable window screen repair services to Colorado Springs homeowners. Call now to get a free quote on your window screen replacement.', N' <!-- ======= Header ======= -->      <section class="d-flex align-items-center header-common header-common-img screenheader-img">          <div class="container">              <div class="row">                  <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column" data-aos="fade-up" data-aos-delay="200">                      <h1 class="text-center">Screens</h1>                  </div>              </div>          </div>      </section><!-- End Header -->      <main id="main">            <!-- ======= Header Description Section ======= -->          <section class="header-common-des about">              <div class="container" data-aos="fade-up">                  <div class="row content">                      <div class="col-xl-12 col-lg-12 col-md-12">                          <h5>                              While you probably know City Glass is expert in glass door and window repair, we also repair and replace window screens and screen doors. We’ll repair tears in your window screens or door screens and if necessary replace and install new ones. Our screens come in a variety of materials and designs to meet your specifications. And you may be pleasantly surprised to discover how economical screen replacement is!                          </h5>                      </div>                  </div>              </div>          </section><!-- End Header Description Section -->          <div class="container">              <hr class="hr-divide m-0" />          </div>          <section id="screen-section-2">              <div class="container screen" data-aos="fade-up">                  <div class="row content">                      <div class="col-xl-12 col-lg-12 col-md-12 pt-4 pt-lg-0" data-aos="fade-right" data-aos-delay="100">                          <div class="section-title">                              <h2>Screens</h2>                          </div>                      </div>                      <div class="col-xl-4 col-lg-4 col-md-4 d-flex" data-aos="fade-right" data-aos-delay="100">                          <div class="slider-box mr-2">                              <div class="slider-box-img">                                  <a href="upload/2021/4/screen-repair011.jpg" class="venobox vbox-item" data-gall="gallery-item">                                      <img data-src="upload/2021/4/screen-repair011.jpg" class="lazy img-fluid" alt="">                                  </a>                              </div>                          </div>                      </div>                      <div class="col-xl-4 col-lg-4 col-md-4 d-flex" data-aos="fade-up" data-aos-delay="100">                          <div class="slider-box ml-2">                              <div class="slider-box-img">                                  <a href="upload/2021/4/screen-repair007.jpg" class="venobox vbox-item" data-gall="gallery-item">                                      <img data-src="upload/2021/4/screen-repair007.jpg" class="lazy img-fluid" alt="">                                  </a>                                                                </div>                          </div>                      </div>                      <div class="col-xl-4 col-lg-4 col-md-4 d-flex" data-aos="fade-left" data-aos-delay="100">                          <div class="slider-box ml-2">                              <div class="slider-box-img">                                  <a href="upload/2021/4/screen-repair013.jpg" class="venobox vbox-item" data-gall="gallery-item">                                      <img data-src="upload/2021/4/screen-repair013.jpg" class="lazy img-fluid" alt="">                                  </a>                              </div>                          </div>                      </div>                  </div>              </div>          </section><!-- 1 Section -->      </main><!-- End #main -->
<section class="bg-primary p-0 hpx-100">
<div class="container">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="upload/2021/4/bbb_logo.png" /> </a></div>
</div>
</div>
</section>

<section class="bg-gray" id="contactuslink">
<div class="container p-2">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
</div>
</div>
</section>
', CAST(N'2021-04-02T12:39:44.767' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (6, N'Windows & Doors', N'windows-doors', N'Colorado Springs Replacement Windows - Door & Window Installation', NULL, 'City Glass Company is your trusted source for replacement windows in Colorado Springs. Call now to receive a free quote on custom door and window installation.', N'<section class="d-flex align-items-center header-common header-common-img windowdoor-img">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column aos-init aos-animate" data-aos="fade-up" data-aos-delay="200">
                <h1 class="text-center">Windows &amp; Doors</h1>
            </div>
        </div>
    </div>
</section>

<main id="main">

    <!-- ======= Header Description Section ======= -->
    <section class="header-common-des about">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h5 class="pb-3">
                        The City Glass custom window replacement services and installation team designs and installs home windows precisely to your preferences.
                        We provide our clients with the highest quality, most energy efficient home windows available. Count on us for great products while we keep prices fair.
                    </h5>
                </div>
                <div class="pt-3 col-12 d-flex justify-content-center align-items-center">
                    <a class="link-btn btn-yellow-xl" href="#brochures">
                        <span class="link-btn-label">Click here for Brochures</span>
                    </a>
                </div>
            </div>
        </div>
    </section><!-- End Header Description Section -->

    <div class="container">
        <hr class="hr-divide">
    </div>

    <!-- ======= 1 Section ======= -->
    <section id="windows-doors-section-1" class="slider-section">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-6 d-flex aos-init aos-animate" data-aos="fade-right" data-aos-delay="100">
                    <div class="slider-box mr-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_one" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_one" data-slide-to="0" class=""></li>
                                        <li data-target="#slider_one" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_one" data-slide-to="2" class="active"></li>
                                        <li data-target="#slider_one" data-slide-to="3" class=""></li>
                                        <li data-target="#slider_one" data-slide-to="4" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/window-door-slider-one.jpg)"></div>
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/window-door-slider-two.jpg)"></div>
                                        <div class="owl-lazy carousel-item active" style="background-image: url(/upload/2021/4/window-door-slider-three.jpg)"></div>
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/window-door-slider-four.jpg)"></div>
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/window-door-slider-five.jpg)"></div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_one" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_one" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Windows</h2>
                        </div>
                        <div class="slider-box-content">
                            <p>
                                Replacement or repair, City Glass is your trusted source for windows. Top quality products with superior service!
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 d-flex aos-init aos-animate" data-aos="fade-left" data-aos-delay="100">
                    <div class="slider-box ml-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_two" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_two" data-slide-to="0" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="2" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="3" class="active"></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="carousel-item" style="background-image: url(/upload/2021/4/res-door-slider-one.jpg)"></div>
                                        <div class="carousel-item" style="background-image: url(/upload/2021/4/res-door-slider-two.jpg)"></div>
                                        <div class="carousel-item" style="background-image: url(/upload/2021/4/res-door-slider-three.jpg)"></div>
                                        <div class="carousel-item active" style="background-image: url(/upload/2021/4/res-door-slider-four.jpg)"></div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_two" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_two" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Doors</h2>
                        </div>
                        <div class="slider-box-content">
                            <p>
                                Let us create the custom glass door that’s perfect for your home or business.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- 1 Section -->


    <section id="brochures" class="pt-0">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h4 style="font-size: 1.75rem;">
                        Brochures
                    </h4>
                    <h5>
                        See below for the full selection of brochures!
                    </h5>
                    <hr class="hr-divide">
                </div>

                <div class="col-xl-12 col-lg-12 col-md-12">
                    <ul class="doc-list">
                        <li>
                            <img class="pdf-icon" src="/upload/2021/4/logo/document.png" alt="">
                            <a href="/upload/2021/4/DaylightMax-Brochure.pdf" title="https://www.cityglasscompany.net/default/document/window-door/DaylightMax-Brochure.pdf" target="blank">DaylightMax Brochure</a>
                        </li>
                        <li>
                            <img class="pdf-icon" src="/upload/2021/4/logo/document.png" alt="">
                            <a href="/upload/2021/4/Simonton-West-Region-Warranty.pdf" title="https://www.cityglasscompany.net/default/document/window-door/Simonton-West-Region-Warranty.pdf" target="blank">Simonton West Region Warranty</a>
                       
                        </li>
                        <li>
                            <img class="pdf-icon" src="/upload/2021/4/logo/document.png" alt="">
                            <a href="/upload/2021/4/West-Patio-Door-Brochure.pdf" title="https://www.cityglasscompany.net/default/document/window-door/West-Patio-Door-Brochure.pdf" target="blank">Sliding Patio Door Guide</a>
                          
                        </li>
                        <li>
                            <img class="pdf-icon" src="/upload/2021/4/logo/document.png" alt="">
                            <a href="/upload/2021/4/Madeira-Brochure.pdf" title="https://www.cityglasscompany.net/default/document/window-door/Madeira-Brochure.pdf" target="blank">Madeira Brochure</a>
                        </li>
                        <li>
                            <img class="pdf-icon" src="/upload/2021/4/logo/document.png" alt="">
                            <a href="/upload/2021/4/Verona-Flier.pdf" title="https://www.cityglasscompany.net/default/document/window-door/Verona-Flier.pdf" target="blank">Verona Flier</a>
                        </li>
                        <li>
                            <img class="pdf-icon" src="/upload/2021/4/logo/document.png" alt="">
                            <a href="/upload/2021/4/Verona-Simonton-Warranty.pdf" title="https://www.cityglasscompany.net/default/document/window-door/Verona-Simonton-Warranty.pdf" target="blank">Simonton Verona Warranty</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
</main>

<section class="bg-primary p-0 hpx-100">
    <div class="container">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3">
                <a href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank" class="h-100">
                    <img class="lazy img-fluid h-100" src="/upload/2021/4/logo/bbb_logo.png" style="">
                </a>
            </div>
        </div>
    </div>
</section>

<section id="contactuslink" class="bg-gray">
    <div class="container p-2">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <a class="link-btn btn-yellow-xl" href="/contact">
                    <span class="link-btn-label">Contact Us</span>
                </a>
            </div>
        </div>
    </div>
</section>
', CAST(N'2021-04-02T16:24:50.793' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (7, N'Services', N'services', N'Glass Services Colorado Springs - Emergency Glass Repair', NULL, 'City Glass Company is the leading provider of glass services in Colorado Springs. Call now if you need emergency glass repair for your home or business.', N'<section class="d-flex align-items-center header-common header-common-img">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column aos-init aos-animate" data-aos="fade-up" data-aos-delay="200">
                <h1 class="text-center">Services</h1>
            </div>
        </div>
    </div>
</section>

<main id="main" class="services">

    <!-- ======= Header Description Section ======= -->
    <section class="header-common-des about">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h5 class="pb-3">
                        Our glass services are perfect for homeowners, property managers and store owners. If your home or business is in need of emergency glass service or maintenance, we’ll make sure your property is safe, secured and repaired as soon as possible.
                    </h5>
                    <div class="emg-call d-flex justify-content-center">
                        <a href="tel:+1719–634–289"><h5 class="d-flex align-items-center"><i class="icofont-phone"></i>Emergency glass service: 719–634–2891</h5></a>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- End Header Description Section -->
    <div class="container">
        <hr class="hr-divide">
    </div>
    <!-- ======= 1 Section ======= -->
    <section id="services-section-1" class="slider-section">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex aos-init aos-animate" data-aos="fade-right" data-aos-delay="100">
                    <div class="slider-box mr-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="owl-lazy carousel-item active" style="background-image: url(/upload/2021/4/iStock-1147286219.jpg)">

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Property Managers</h2>
                        </div>
                        <div class="slider-box-content">
                            <p>
                                Property management involves many responsibilities, but glass repair doesn’t have to be one of them. Let City Glass take glass repair, maintenance and installation off your to-do list.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 d-flex aos-init aos-animate" data-aos="fade-left" data-aos-delay="100">
                    <div class="slider-box ml-2">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_two" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_two" data-slide-to="0" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="1" class="active"></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="carousel-item" style="background-image: url(/upload/2021/4/emergency-glass-service001.jpg)">

                                        </div>
                                        <!-- Slide 2 -->
                                        <div class="carousel-item active" style="background-image: url(/upload/2021/4/board-up-services.jpg)">

                                        </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_two" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_two" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="slider-box-title">
                            <h2>Emergency</h2>
                        </div>
                        <div class="slider-box-content">
                            <p>
                                City Glass provides 24 hour emergency board up and repair services. Our emergency glass services include glass repair, replacement windows, glass door repair and more.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- 1 Section -->

</main>

<section class="bg-primary p-0 hpx-100">
    <div class="container">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3">
                <a href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank" class="h-100">
                    <img class="lazy img-fluid h-100" src="/upload/2021/4/bbb_logo.png" style="">
                </a>
            </div>
        </div>
    </div>
</section>

<section id="contactuslink" class="bg-gray">
    <div class="container p-2">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <a class="link-btn btn-yellow-xl" href="/contact">
                    <span class="link-btn-label">Contact Us</span>
                </a>
            </div>
        </div>
    </div>
</section>
', CAST(N'2021-04-07T14:13:41.773' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (8, N'Commercial', N'commercial', N'Commercial Glass Company Colorado Springs - Storefront Windows & Doors', NULL, 'As the leading commercial glass company in Colorado Springs, we offer affordable prices on storefront windows & doors. Call City Glass Company today to get a free quote.', N'<section class="d-flex align-items-center header-common header-common-img">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column aos-init aos-animate" data-aos="fade-up" data-aos-delay="200">
                <h1 class="text-center">Commercial</h1>
            </div>
        </div>
    </div>
</section>

<main id="main">
    <!-- ======= Header Description Section ======= -->
    <section class="header-common-des">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h5>
                        Area business owners trust City Glass to execute their glass and mirror installations on time, on budget, and with excellent results.
                    </h5>
                </div>
            </div>
        </div>
    </section><!-- End Header Description Section -->
    <div class="container">
        <hr class="hr-divide">
    </div>
    <!-- ======= New Construction Section ======= -->
    <section id="new-construction" class="about">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-12 d-flex aos-init aos-animate" data-aos="fade-right" data-aos-delay="100">
                    <div class="hero-img">
                        <img class="lazy img-fluid" alt="" src="/upload/2021/4/new-construction001.jpg" style="">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12 pt-4 pt-lg-0">
                    <div class="section-title">
                        <h2>New Construction</h2>
                    </div>
                    <div class="section-text">
                        <p class="text-justify">
                            City Glass has been improving Colorado Springs businesses with glass storefronts since its inception in 1950. Today, our completed glass wall projects can be seen in and around Colorado Springs. We purchase glass wall products from all of the major suppliers.
                        </p>
                    </div>

                    <div class="section-link">
                        <a href="/new-construction" class="link-btn"><span class="link-btn-label">Learn More</span></a>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- End New Construction Section -->
    <div class="container">
        <hr class="hr-divide">
    </div>
    <!-- ======= Repair & Replace Section ======= -->
    <section id="repair-replace" class="about">
        <div class="container aos-init" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-12 pt-4 pt-lg-0 order-1">
                    <div class="section-title">
                        <h2>Repair &amp; Replace</h2>
                    </div>
                    <div class="section-text">
                        <p class="text-justify">
                            City Glass repairs glass doors throughout the Colorado Springs region. Not only do we provide replacement glass for broken or cracked door windows, we repair and replace closer mechanisms of glass doors as well.
                        </p>
                        <p class="text-justify">
                            Possible causes for window or glass damage include hail, rotting wood frames, broken panes, failed insulation, broken seals, shrunken vinyl and drafty or sticking windows. Whether the vinyl has shrunk or the insulated glass unit has shifted or failed, we’re here to help.
                        </p>
                    </div>
                    <div class="section-link">
                        <a href="/repair-replace" class="link-btn"><span class="link-btn-label">Learn More</span></a>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12 d-flex order-0 aos-init" data-aos="fade-right" data-aos-delay="100">
                    <div class="hero-img">
                        <img data-src="/upload/2021/4/board-up-services-commercial.jpg" class="lazy img-fluid" alt="" src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==">
                    </div>
                </div>
            </div>
        </div>
    </section><!-- End Repair & Replace Section -->
    <div class="container">
        <hr class="hr-divide">
    </div>
    <!-- ======= Services Section ======= -->
    <section id="services" class="about">
        <div class="container aos-init" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-6 col-lg-6 col-md-12 d-flex aos-init" data-aos="fade-right" data-aos-delay="100">
                    <div class="hero-img">
                        <img data-src="/upload/2021/4/commercial-windows-005.jpg" class="lazy img-fluid" alt="" src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12 pt-4">
                    <div class="section-title">
                        <h2>Services</h2>
                    </div>
                    <div class="section-text">
                        <p class="text-justify">
                            Our exterior services include glass storefront installation, glass door and screen repair, as well as insulated window replacement. Indoors we provide mirrors, glass cabinets, closer adjustments, glass walls and more.
                        </p>
                    </div>
                    <div class="section-link">
                        <a href="/services" class="link-btn"><span class="link-btn-label">Learn More</span></a>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- End Services Section -->
</main>

<section class="bg-primary p-0 hpx-100">
    <div class="container">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3">
                <a href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank" class="h-100">
                    <img data-src="/upload/2021/4/bbb_logo.png" class="lazy img-fluid h-100" src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==">
                </a>
            </div>
        </div>
    </div>
</section>

<section id="contactuslink" class="bg-gray">
    <div class="container p-2">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <a class="link-btn btn-yellow-xl" href="/contact">
                    <span class="link-btn-label">Contact Us</span>
                </a>
            </div>
        </div>
    </div>
</section>', CAST(N'2021-04-07T14:14:19.090' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (9, N'New Construction', N'new-construction', N'Commercial Windows Colorado Springs - Storefront Glass Doors', NULL, 'Local business owners rely on City Glass Company to provide commercial windows in Colorado Springs. Call now to get the best deals on storefront glass doors and windows.', N'<section class="d-flex align-items-center header-common header-common-img lazy" style="background-image: url(&quot;/upload/2021/4/door-header.jpg&quot;);">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column aos-init aos-animate" data-aos="fade-up" data-aos-delay="200">
                <h1 class="text-center">New Construction</h1>
            </div>
        </div>
    </div>
</section>

<main id="main">

    <!-- ======= Header Description Section ======= -->
    <section class="header-common-des">
        <div class="container aos-init aos-animate" data-aos="fade-up">
            <div class="row content">
                <div class="col-xl-12 col-lg-12 col-md-12">
                    <h5>
                        Whatever your business, City Glass has the glass products you need for function and design. Area business owners trust us to execute their glass and mirror installations on time, on budget, and with excellent results. They have come to rely on exceptional customer service as well, and that’s why we are a favorite glass and mirror source throughout the Pikes Peak Region.
                    </h5>
                </div>
            </div>
        </div>
    </section><!-- End Header Description Section -->
    <div class="container">
        <hr class="hr-divide">
    </div>

    <section>
        <div class="container">
            <div class="card bg-gray shadow-sm border-0">
                <div class="row no-gutters">
                    <div class="col-md-6" style="background: #868e96;">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_one" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_one" data-slide-to="0" class="active"></li>
                                        <li data-target="#slider_one" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_one" data-slide-to="2" class=""></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="owl-lazy carousel-item active" style="background-image: url(/upload/2021/4/store_front_one.jpg)"></div>
                                        <!-- Slide 2 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/store_front_two.jpg)"></div>
                                        <!-- Slide 3 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/store_front_three.jpg)"></div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_one" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_one" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <div class="section-title">
                                <h2>Storefront</h2>
                            </div>
                            <p class="card-text">We may have completed more storefront glass projects than any other glass company in Southern Colorado. From gas stations to car dealerships and coffee shops to strip malls, we do it all.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="container">
            <div class="card bg-gray shadow-sm border-0">
                <div class="row no-gutters">
                    <div class="col-lg-6 col-md-6 col-sm-12 order-2 order-md-0">
                        <div class="card-body">
                            <div class="section-title">
                                <h2>Curtainwall</h2>
                            </div>
                            <p class="card-text">City Glass has been installing curtain walls since 1950. We have knowledgeable installers and the proper equipment needed for proper installation.</p>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-12 order-sm-0 order-md-1" style="background: #868e96;">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_two" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_two" data-slide-to="0" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_two" data-slide-to="2" class="active"></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/curtain-wall-one.jpg)"></div>
                                        <!-- Slide 2 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/curtain-wall-two.jpg)"></div>
                                        <!-- Slide 3 -->
                                        <div class="owl-lazy carousel-item active" style="background-image: url(/upload/2021/4/curtain-wall-three.jpg)"></div>
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_two" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_two" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="container">
            <div class="card bg-gray shadow-sm border-0">
                <div class="row no-gutters">
                    <div class="col-md-6" style="background: #868e96;">
                        <div class="slider-box-img">
                            <div class="sideslide">
                                <div id="slider_three" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#slider_three" data-slide-to="0" class=""></li>
                                        <li data-target="#slider_three" data-slide-to="1" class=""></li>
                                        <li data-target="#slider_three" data-slide-to="2" class="active"></li>
                                    </ol>
                                    <div class="carousel-inner" role="listbox">
                                        <!-- Slide 1 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/doors-one.jpg)"></div>
                                        <!-- Slide 2 -->
                                        <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/door-two.jpg)"></div>
                                        <!-- Slide 3 -->
                                        <div class="owl-lazy carousel-item active" style="background-image: url(/upload/2021/4/door-three.jpg)"></div>
                                        
                                    </div>
                                    <a class="carousel-control-prev" href="#slider_three" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#slider_three" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <div class="section-title">
                                <h2>Doors</h2>
                            </div>
                            <p class="card-text">City Glass is Colorado Springs go–to company for commercial glass doors. We have installed thousands of glass storefront doors in Southern Colorado and you can count on the expertise of our glass technicians.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</main>

<section class="bg-primary p-0 hpx-100">
    <div class="container">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3">
                <a href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank" class="h-100">
                    <img class="lazy img-fluid h-100" src="/upload/2021/4/bbb_logo.png" style="">
                </a>
            </div>
        </div>
    </div>
</section>

<section id="contactuslink" class="bg-gray">
    <div class="container p-2">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <a class="link-btn btn-yellow-xl" href="/contact">
                    <span class="link-btn-label">Contact Us</span>
                </a>
            </div>
        </div>
    </div>
</section>', CAST(N'2021-04-07T14:36:24.210' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (10, N'Repair & Replace', N'repair-replace', N'Commercial Glass Repair Colorado Springs - Commercial Door Repair', NULL, 'City Glass Company offers commercial glass repair services to Colorado Springs business owners. Call now to receive fast and affordable commercial door & window repair.', N'<section class="d-flex align-items-center header-common header-common-img">
        <div class="container">
            <div class="row">
                <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column aos-init aos-animate" data-aos="fade-up" data-aos-delay="200">
                    <h1 class="text-center">Repair &amp; Replace</h1>
                </div>
            </div>
        </div>
    </section>
	
<main id="main">

        <!-- ======= Header Description Section ======= -->
        <section class="header-common-des">
            <div class="container aos-init aos-animate" data-aos="fade-up">
                <div class="row content">
                    <div class="col-xl-12 col-lg-12 col-md-12">
                        <h5>
                            City Glass repairs glass doors throughout the Colorado Springs region. Not only do we provide replacement glass for broken or cracked door windows, repair and replace closer mechanisms of glass doors as well. Without proper glass repair and repairs on the door itself the problem can continue and the glass may break again. Our comprehensive approach ensures that our customers will be pleased with the product.
                        </h5>
                    </div>
                </div>
            </div>
        </section><!-- End Header Description Section -->
        <div class="container">
            <hr class="hr-divide">
        </div>
        <!-- ======= 1 Section ======= -->
        <section id="repair-replace-section-1" class="slider-section">
            <div class="container aos-init aos-animate" data-aos="fade-up">
                <div class="row content">
                    <div class="col-xl-6 col-lg-6 col-md-6 d-flex aos-init aos-animate" data-aos="fade-right" data-aos-delay="100">
                        <div class="slider-box mr-2">
                            <div class="slider-box-img">
                                <div class="sideslide">
                                    <div id="slider_one" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                        <ol class="carousel-indicators">
                                            <li data-target="#slider_one" data-slide-to="0" class="active"></li>
                                            <li data-target="#slider_one" data-slide-to="1" class=""></li>
                                        </ol>
                                        <div class="carousel-inner" role="listbox">
                                            <!-- Slide 1 -->
                                            <div class="owl-lazy carousel-item active" style="background-image: url(/upload/2021/4/doors-hardware532.jpg)">

                                            </div>
                                            <!-- Slide 2 -->
                                            <div class="owl-lazy carousel-item" style="background-image: url(/upload/2021/4/doors-hardware173.jpg)">

                                            </div>
                                        </div>
                                        <a class="carousel-control-prev" href="#slider_one" role="button" data-slide="prev">
                                            <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="carousel-control-next" href="#slider_one" role="button" data-slide="next">
                                            <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="slider-box-title">
                                <h2>Doors &amp; Hardware</h2>
                            </div>
                            <div class="slider-box-content">
                                <p>
                                    Whether the wind caught your glass door and caused the closer to fail or the closer is not performing as it used to, City Glass can assist in replacing or repairing the door closer. We can also recommend options to improve the performance of your commercial glass door, keeping your door operating longer without repairs.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 d-flex aos-init aos-animate" data-aos="fade-left" data-aos-delay="100">
                        <div class="slider-box ml-2">
                            <div class="slider-box-img">
                                <div class="sideslide">
                                    <div id="slider_two" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                                        <ol class="carousel-indicators">
                                            <li data-target="#slider_two" data-slide-to="0" class=""></li>
                                            <li data-target="#slider_two" data-slide-to="1" class="active"></li>
                                        </ol>
                                        <div class="carousel-inner" role="listbox">
                                            <!-- Slide 1 -->
                                            <div class="carousel-item active carousel-item-left" style="background-image: url(/upload/2021/4/board-up-services-repair.jpg)">

                                            </div>
                                            <!-- Slide 2 -->
                                            <div class="carousel-item carousel-item-next carousel-item-left" style="background-image: url(/upload/2021/4/board-up-services-626.jpg)">

                                            </div>
                                        </div>
                                        <a class="carousel-control-prev" href="#slider_two" role="button" data-slide="prev">
                                            <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="carousel-control-next" href="#slider_two" role="button" data-slide="next">
                                            <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="slider-box-title">
                                <h2>Glass</h2>
                            </div>
                            <div class="slider-box-content">
                                <p>
                                    Each building and business has a unique look as well as unique needs which require a helping and trusting hand. City Glass will help you pick the correct glass to meet your specifications. We’ll make sure your glass storefront works perfectly and looks great, too.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section><!-- 1 Section -->

    </main>
	
<section class="bg-primary p-0 hpx-100">
    <div class="container">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3">
                <a href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank" class="h-100">
                    <img class="lazy img-fluid h-100" src="/upload/2021/4/bbb_logo.png" style="">
                </a>
            </div>
        </div>
    </div>
</section>

<section id="contactuslink" class="bg-gray">
    <div class="container p-2">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <a class="link-btn btn-yellow-xl" href="/contact">
                    <span class="link-btn-label">Contact Us</span>
                </a>
            </div>
        </div>
    </div>
</section>

', CAST(N'2021-04-07T14:36:54.637' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (11, N'About', N'about', N'About', NULL, NULL, N'<!-- Start Header -->
<section class="d-flex align-items-center header-common header-common-img" style="background-image:url(upload/2021/4/common-header.png)">
    <div class="container">
        <div class="row">
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column" data-aos="fade-up" data-aos-delay="200">
                <h1 class="text-center">About Us</h1>
            </div>
        </div>
    </div>
</section><!-- End Header -->
<!-- Start Our Company -->
<section id="our-company">
    <div class="container" data-aos="fade-up">
        <div class="row content">
            <div class="pt-5 col-xl-5 col-lg-5 col-md-5 text-center">
                <img data-src="upload/2021/4/City-Logo-Round.png" class="lazy img-fluid" alt="" />
            </div>
            <div class="col-xl-7 col-lg-7 col-md-7 pt-2 pt-lg-0" data-aos="fade-left" data-aos-delay="100">
                <div class="section-title">
                    <h2>City Glass Company</h2>
                </div>
                <div class="section-text">
                    <p class="text-justify">
                        Our glass services are perfect for homeowners, property managers and store owners. If your home or business is in need of emergency glass service or maintenance, we’ll make sure your property is safe, secured and repaired as soon as possible.
                    </p>
                    <p class="text-justify">
                        We are in business to serve customers who require anything involving glass, mirrors and related materials – in residential, commercial and new construction settings. This includes: replacing glass in homes and businesses, installing new aluminum store fronts, curtainwall and glass for new construction of commercial buildings, repairing storm windows and doors, installing custom mirrors and shower enclosures, providing glass table tops, screens, picture frame glass, and aquarium glass repairs.
                    </p>
                </div>
                <div class="section-link">
                    <a href="/about#news-video" class="link-btn"><span class="link-btn-label">Watch Our Story</span></a>
                </div>
            </div>
        </div>
    </div>
    <div class="container pt-4">
        <hr class="hr-divide" />
    </div>
</section>
<!-- End Our Company -->

<section id="project-gallery" class="pt-0">
    <div class="container" data-aos="fade-up">
        <div class="row content">
            <div class="col-xl-12 col-lg-12 col-md-12 pt-4 pt-lg-0" data-aos="fade-up" data-aos-delay="100">
                <div class="section-title">
                    <h2>Project Gallery</h2>
                </div>
            </div>
            <div class="col-xl-12 col-lg-12 col-md-12 d-flex" data-aos="fade-up" data-aos-delay="200">
                <div class="sideslide" style="height: 70vh">
                    <div id="slider_two" class="carousel slide carousel-fade pointer-event" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#slider_two" data-slide-to="0" class="active"></li>
                            <li data-target="#slider_two" data-slide-to="1" class=""></li>
                            <li data-target="#slider_two" data-slide-to="2" class=""></li>
                            <li data-target="#slider_two" data-slide-to="3" class=""></li>
                            <li data-target="#slider_two" data-slide-to="4" class=""></li>
                            <li data-target="#slider_two" data-slide-to="5" class=""></li>
                            <li data-target="#slider_two" data-slide-to="6" class=""></li>
                            <li data-target="#slider_two" data-slide-to="7" class=""></li>
                            <li data-target="#slider_two" data-slide-to="8" class=""></li>
                            <li data-target="#slider_two" data-slide-to="9" class=""></li>
                        </ol>
                        <div class="carousel-inner" role="listbox">
                            <div class="carousel-item active" style="background-image: url(upload/2021/4/Project-Gallery.jpg"></div>
                            
                            <div class="owl-lazy carousel-item " style="background-image: url(upload/2021/4/iStock-525964080.jpg"></div>

                            <div class="owl-lazy carousel-item " style="background-image: url(upload/2021/4/city-glass-company-old-chicago03.jpg"></div>

                            <div class="owl-lazy carousel-item" style="background-image: url(upload/2021/4/IMG_1442.jpg"></div>

                            <div class="owl-lazy carousel-item " style="background-image: url(upload/2021/4/iStock-183289827.jpg"></div>

                            <div class="owl-lazy carousel-item " style="background-image: url(upload/2021/4/board-up-services-624.jpg"></div>

                            <div class="owl-lazy carousel-item " style="background-image: url(upload/2021/4/Double-Hung-Windows.jpg"></div>

                            <div class="owl-lazy carousel-item " style="background-image: url(upload/2021/4/glass-shelves003.jpg"></div>

                            <div class="owl-lazy carousel-item " style="background-image: url(upload/2021/4/tub-glass-enclosure003.jpg"></div>

                            <div class="owl-lazy carousel-item" style="background-image: url(upload/2021/4/shower-enclosure003.jpg">  </div>
                        </div>
                        <a class="carousel-control-prev" href="#slider_two" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon icofont-simple-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#slider_two" role="button" data-slide="next">
                            <span class="carousel-control-next-icon icofont-simple-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<section id="career-employment">
    <div class="row">
        <div class="col-12 d-flex justify-content-center flex-wrap align-items-center">
            <img data-src="upload/2021/4/City-Glass-Company.png" class="lazy img-fluid" style="max-height: 190px" alt="">
        </div>
    </div>
    <div class="bg-gray">
        <div class="container p-4">
            <div class="row pt-4 pb-3">
                <div class="col-12 d-flex justify-content-center flex-wrap align-items-center">
                    <h3 class="text-center">
                        Interested in joining our company?
                    </h3>
                </div>
                <div class="col-12 d-flex justify-content-center flex-wrap align-items-center">
                    <h5 class="text-center">
                        Apply online now!
                    </h5>
                </div>
                <div class="pt-3 pb-3 col-12 d-flex justify-content-center flex-wrap align-items-center">
                    <a class="link-btn btn-yellow-xl" href="/employment/application">
                        <span class="link-btn-label">Online Application</span>
                    </a>
                </div>
            </div>
        </div>
    </div>

</section>

<section id="history">
    <div class="container" data-aos="fade-up" data-aos-delay="100">
        <div class="row content">
            <div class="col-xl-6 col-lg-6 col-md-6 pt-4 pt-lg-0" data-aos="fade-right" data-aos-delay="200">
                <div class="section-title">
                    <h2>Our History</h2>
                </div>
                <div class="section-text">
                    <p class="text-justify">
                        City Glass Company has been a mainstay in the Pikes Peak Region since founded by James H. Davidson in 1950. The glass and mirror company has been family owned and operated since its inception and is proud to continue to operate in the family tradition today.
                    </p>
                </div>
            </div>
            <div class="col-xl-6 col-lg-6 col-md-6 d-flex" data-aos="fade-left" data-aos-delay="200">
                <div class="hero-img">
                    <img data-src="upload/2021/4/Our-History.png" class="lazy img-fluid" alt="">
                </div>
            </div>
        </div>
    </div>
</section>

<section id="news-video" class="bg-gray">
    <div class="container" data-aos="fade-up" data-aos-delay="100">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="pb-3 text-center">
                    Cityglass overview!
                </h3>
                <div class="video-wrapper">
                    <video playsinline loop poster="upload/2021/4/city_glass_video_cover.jpg" preload="none" controls class="lazy">
                        <data-src src="upload/2021/4/city_glass_final_compressed.mp4" type="video/mp4"></data-src>
                    </video>
                    <a class="video-playpause"><i class="icofont-play-alt-2"></i></a>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12 pt-5">
                <div class="d-flex flex-wrap container justify-content-center" data-aos="fade-up">
                    <h4 class="pb-3 text-center">
                        Interested in seeing more of our instructional videos? Subscribe to our YouTube channel
                    </h4>
                    <a href="https://www.youtube.com/channel/UCfwZn0-eGe72Aj96cnfg9mw" target="_blank">
                        <img data-src="upload/2021/4/Subscribe.png" alt="" title="" class="lazy img-fluid wf-500">
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>

<section id="faq" class="faq section-bg">
    <div class="container">

        <div class="section-title">
            <h2>Frequently Asked Questions</h2>
        </div>

        <div class="faq-list">
            <ul>
                <li data-aos="fade-up">
                    <i class="bx bx-help-circle icon-help"></i>
                    <a data-toggle="collapse" class="" href="#faq-list-1" aria-expanded="true">What is so special about the relationship between high altitude and glazing? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                    <div id="faq-list-1" class="collapse show" data-parent=".faq-list" style="">
                        <p>
                            City Glass takes extra precautions when installing windows into a home or business located at high elevation. We make sure the windows we use at high altitude have “breather tubes”, which help to relieve the pressure between glass panes that occurs during transportation between altitudes.
                        </p>
                    </div>
                </li>

                <li data-aos="fade-up" data-aos-delay="100">
                    <i class="bx bx-help-circle icon-help"></i> <a data-toggle="collapse" href="#faq-list-2" class="collapsed" aria-expanded="false">What do breather tubes do? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                    <div id="faq-list-2" class="collapse" data-parent=".faq-list" style="">
                        <p>
                            Windows that have breather tubes are usually manufactured at lower elevations. The tube, made of aluminum, is installed between the panes of window glass. When moving windows from the manufacturer to the installation site at higher (or lower) elevations, the breather tube will be open to allow air pressure between panes of glass to be equalized in the new climate. Once this has occurred, the 3 to 6 inch tube may be crimped shut. The window will then be acclimated and expected to offer a long life of service in its new surroundings.
                        </p>
                    </div>
                </li>

                <li data-aos="fade-up" data-aos-delay="200">
                    <i class="bx bx-help-circle icon-help"></i> <a data-toggle="collapse" href="#faq-list-3" class="collapsed" aria-expanded="false">If a window gets broken in my home or business, does City Glass provide emergency service? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                    <div id="faq-list-3" class="collapse" data-parent=".faq-list" style="">
                        <p>
                            Yes. Just call our 24-hour emergency service department at 719-634-2891. We are here to serve you anytime of the day or night.
                        </p>
                    </div>
                </li>

                <li data-aos="fade-up" data-aos-delay="300">
                    <i class="bx bx-help-circle icon-help"></i> <a data-toggle="collapse" href="#faq-list-4" class="collapsed" aria-expanded="false">How do I know City Glass is a reputable company? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                    <div id="faq-list-4" class="collapse" data-parent=".faq-list" style="">
                        <p>
                            City Glass has been in the glass and glazing business since 1950. We are the oldest and largest full-service glass and glazing company in the Pikes Peak Region. Our glass and glazing company has an A+ Rating with the Better Business Bureau. With over 35 employees, and 20 service vehicles, we offer fair, fast, and honest service on small and large-scale glass and glazing projects throughout the Pikes Peak Region.
                        </p>
                    </div>
                </li>

                <li data-aos="fade-up" data-aos-delay="400">
                    <i class="bx bx-help-circle icon-help"></i> <a data-toggle="collapse" href="#faq-list-5" class="collapsed" aria-expanded="false">What core service does City Glass provide? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                    <div id="faq-list-5" class="collapse" data-parent=".faq-list" style="">
                        <p>
                            We are in business to serve customers who need basically anything involving glass, mirrors and related materials – in residential, commercial and new construction settings. This includes the following: replacing glass in homes and businesses, installing new aluminum store fronts, curtainwall and glass for new construction of commercial buildings, repairing storm windows and doors, installing custom mirrors and shower enclosures, providing glass table tops, screens, picture frame glass, and aquarium glass repairs.
                        </p>
                    </div>
                </li>
                <li data-aos="fade-up" data-aos-delay="600">
                    <i class="bx bx-help-circle icon-help"></i> <a data-toggle="collapse" href="#faq-list-6" class="collapsed" aria-expanded="false">Does City Glass Company repair auto glass? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                    <div id="faq-list-6" class="collapse" data-parent=".faq-list" style="">
                        <p>
                            No. Unfortunately, we do not sell or install automotive glass.
                        </p>
                    </div>
                </li>
                <li data-aos="fade-up" data-aos-delay="700">
                    <i class="bx bx-help-circle icon-help"></i> <a data-toggle="collapse" href="#faq-list-7" class="collapsed" aria-expanded="false">Are you accepting job applications? <i class="bx bx-chevron-down icon-show"></i><i class="bx bx-chevron-up icon-close"></i></a>
                    <div id="faq-list-7" class="collapse" data-parent=".faq-list" style="">
                        <p>
                            We certainly are! You may come into the shop or apply online above.
                        </p>
                    </div>
                </li>
            </ul>
        </div>

    </div>
</section>


<section class="bg-primary p-0 hpx-100">
    <div class="container">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="upload/2021/4/bbb_logo.png" /> </a></div>
        </div>
    </div>
</section>

<section class="bg-gray" id="contactuslink">
    <div class="container p-2">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
        </div>
    </div>
</section>', CAST(N'2021-04-07T14:38:10.810' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (12, N'Contact', N'contact', N'Contact', NULL, NULL, N'<!-- ======= Header ======= -->
    <section class="d-flex align-items-center header-common header-contact" style="background-image:url(upload/2021/4/contact-header.jpg)">
        <div class="background">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12 col-lg-12 col-md-12 d-flex flex-column" data-aos="fade-up" data-aos-delay="200">
                        <h1 class="text-center">Contact Us</h1>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- End Header -->
<main id="main">
    <div class="contact">
        <div class="bg-gray">
            <div class="container p-4">
                <div class="emg-call row pt-4 pb-3">
                    <div class="col-12 d-flex justify-content-center flex-wrap align-items-center"  data-aos="fade-left">
                        <h3 class="text-center">
                            Call Or Visit Us
                        </h3>
                    </div>
                    <div class="pt-3 pb-3 col-12 d-flex justify-content-center flex-wrap align-items-center" data-aos="fade-right">
                        <a  href="tel:+1719–634–289">
                            <div class="d-flex justify-content-center">
                                <h5 class="d-flex align-items-center"><i class="icofont-phone"></i>719–634–2891</h5>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <section id="contact" class="contact">
            <div class="container aos-init aos-animate" data-aos="fade-up">
                <div class="section-title">
                    <h2>Showroom</h2>
                </div>
                <div class="section-info">
                    <p>Hours: Monday – Friday 8 a.m. – 5 p.m.</p>
                    <p>
                        Parking is available off of Colorado Ave,
                        West of the Colorado Avenue entrance and from the North side of the building off of Spruce Street.
                    </p>
                    <p class="m-0">414 West Colorado Avenue</p>
                    <p>Colorado Springs, CO 80905</p>
                </div>                
                <div>
                    <iframe class="lazy" style="border: 0; width: 100%; height: 270px;" data-src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3107.9758087678056!2d-104.83560218529229!3d38.83301485834294!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x871345255b64f729%3A0x6e8c72a1adc4ea3f!2sCity%20Glass%20Company!5e0!3m2!1sen!2s!4v1582566439424!5m2!1sen!2s" data-src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3107.9758087678056!2d-104.83560218529229!3d38.83301485834294!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x871345255b64f729%3A0x6e8c72a1adc4ea3f!2sCity%20Glass%20Company!5e0!3m2!1sen!2s!4v1582566439424!5m2!1sen!2s" frameborder="0" allowfullscreen=""></iframe>
                </div>
            </div>
        </section>

        <section id="emailus" class="bg-gray">
            <div class="container py-2">
                <header class="text-center mb-2 pb-3">
                    <div class="section-title">
                        <h2>Email Us</h2>
                    </div>
                </header>
                <div class="row">
                    <div class="col-md-4">
                        <div class="show">
                            <!-- Tabs nav -->
                            <div class="nav flex-column nav-pills nav-pills-custom" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                <a class="nav-link mb-3 p-3 active" id="v-pills-home-tab" data-val="CommercialGlassWindowsAndDoors" data-cat="Commercial Glass,Windows,& doors" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-home" aria-selected="true">
                                    <i class="icofont-curved-right"></i>
                                    <span class="">Glass, Windows & doors</span>
                                </a>

                                <a class="nav-link mb-3 p-3" id="v-pills-profile-tab" data-val="LargeScaleGlassAndMirrorBidss" data-cat="Large-scale glass and mirror bids" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-profile" aria-selected="false">
                                    <i class="icofont-curved-right"></i>
                                    <span class="">Large-scale glass and mirror bids</span>
                                </a>

                                <a class="nav-link mb-3 p-3" id="v-pills-messages-tab" data-val="MirrorShowerGlassInstallation" data-cat="Mirror & shower glass installation" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-messages" aria-selected="false">
                                    <i class="icofont-curved-right"></i>
                                    <span class="">Mirror & shower glass installation</span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <!-- Tabs content -->
                        <div class="tab-content" id="v-pills-tabContent">
                            <div class="tab-pane fade rounded bg-white show active p-3" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab">
                               
                                    <form data-ajax-url="/ContactSendMessage/sendcontactmessage"
                                          data-ajax="true"
                                          data-ajax-begin="App.LoaderShow();"
                                          data-ajax-complete="App.LoaderHide();"
                                          data-ajax-success="App.AjaxFormPostSuccess(data); App.AjaxFormReset(''FormSendContactMessage'')"
                                          data-ajax-failure="App.LoaderHide();"
                                          id="FormSendContactMessage"
                                          method="post"
                                          novalidate="novalidate" class="justify-content-center">

                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 mb-3">
                                                <div class="form-group" style="margin-bottom: 0px;">
                                                    <label class="sr-only">Glass for</label>
                                                    <select class="form-control form-control-lg" placeholder="Please select" data-val="true" data-val-required="Please select" id="RecipientEmail" name="RecipientEmail" aria-describedby="RecipientEmail-error">
                                                        <option value="">Please select ...</option>
                                                        <option value="davidc@cityglasscompany.net">Commercial</option>
                                                        <option value="angie@cityglasscompany.net">Residential</option>
                                                    </select>                                                   
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 mb-3">
                                                <div class="form-group" style="margin-bottom: 0px;">
                                                    <label class="sr-only">Name</label>
                                                    <input class="form-control form-control-lg" type="text" id="contactName" name="contactName" placeholder="Name" data-val="true" data-val-required="Please enter name.">
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 mb-3">
                                                <div class="form-group" style="margin-bottom: 0px;">
                                                    <label class="sr-only">Email</label>
                                                    <input class="form-control form-control-lg" type="text" id="contactEmail" name="contactEmail" placeholder="Email" data-val="true" data-val-required="Please enter a valid email address.">
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 mb-3">
                                                <div class="form-group" style="margin-bottom: 0px;">
                                                    <label class="sr-only">Phone</label>
                                                    <input class="form-control form-control-lg" type="text" id="contactPhone" name="contactPhone" placeholder="Phone" data-val="true" data-val-required="Please enter phone number.">
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 mb-3">
                                                <div class="form-group" style="margin-bottom: 0px;">
                                                    <label class="sr-only">Subject</label>
                                                    <input class="form-control form-control-lg" type="text" id="contactSubject" name="contactSubject" placeholder="Subject" data-val="true" data-val-required="Subject is required.">
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 mb-3">
                                                <div class="form-group" style="margin-bottom: 0px;">
                                                    <label class="sr-only">Message</label>
                                                    <textarea class="form-control form-control-lg" id="contactMessage" name="contactMessage" placeholder="Message" rows="5" data-val="true" data-val-required="Message is required."></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 mb-3 d-flex justify-content-center align-items-center">
                                                <input id="messageCategory" name="messageCategory" type="hidden" value="Commercial Glass, Windows & doors" />
                                                <input id="messageCategoryValue" name="messageCategoryValue" type="hidden" value="CommercialGlassWindowsAndDoors" />
                                                <button type="submit" class="link-btn btn-yellow-xl" id="btn-contact-sendmessage">
                                                    <span class="link-btn-label">Send</span>
                                                </button>
                                            </div>
                                        </div>
                                    </form>
                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
		<section class="bg-primary p-0 hpx-100">
    <div class="container">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="upload/2021/4/bbb_logo.png" /> </a></div>
        </div>
    </div>
</section>

<section class="bg-gray" id="contactuslink">
    <div class="container p-2">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
        </div>
    </div>
</section>
    </main>', CAST(N'2021-04-07T14:52:37.140' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (13, N'Employment Application', N'employment/application', N'', NULL, NULL, N'<main data-aos="fade-up" id="main" style="min-height: 81.1vh">
    <!-- ======= Employment Application Section ======= -->
    <section id="employment-application">
        <div class="container">
            <form asp-action="Application" asp-controller="Employment" class="validate-form form-horizontal" id="employment-application-form" method="POST">
                <div class="row content employment-application-form mt-4">
                    <div class="col-xl-12 col-lg-12 col-md-12 mt-4 mb-4">
                        <h4>Employment Application</h4>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12">
                        <div class="form-validation-summary mb-4">
                            <div asp-validation-summary="None" class="text-danger">&nbsp;</div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4"><label>* indicates required field</label></div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="firstName">First name *</label> <input class="form-control" data-val="true" data-val-required="Please enter first name." id="firstName" name="firstName" type="text" value="" />
                        <div class="field-validation-valid" data-valmsg-for="firstName" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastName">Last name *</label> <input class="form-control" data-val="true" data-val-required="Please enter last name." id="lastName" name="lastName" type="text" value="" />
                        <div class="field-validation-valid" data-valmsg-for="lastName" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="emailAddress">Email *</label> <input class="form-control" data-val="true" data-val-required="Please enter a valid email address." id="emailAddress" name="emailAddress" type="email" value="" />
                        <div class="field-validation-valid" data-valmsg-for="emailAddress" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="phoneNumber">Phone *</label> <input class="form-control" data-val="true" data-val-required="Please enter a valid phone number." id="phoneNumber" name="phoneNumber" type="text" value="" />
                        <div class="field-validation-valid" data-valmsg-for="phoneNumber" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="secondaryPhoneNumber">Secondary phone</label> <input class="form-control" id="secondaryPhoneNumber" name="secondaryPhoneNumber" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="secondaryPhoneNumber" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="referredBy">Referred by</label> <input class="form-control" id="referredBy" name="referredBy" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="referredBy" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="presentAddress">Present address *</label> <input class="form-control" data-val="true" data-val-required="Please enter present address." id="presentAddress" name="presentAddress" type="text" value="" />
                        <div class="field-validation-valid" data-valmsg-for="presentAddress" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="city">City *</label> <input class="form-control" data-val="true" data-val-required="Please enter city." id="city" name="city" type="text" value="" />
                        <div class="field-validation-valid" data-valmsg-for="city" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="state">State *</label> <input class="form-control" data-val="true" data-val-required="Please enter state." id="state" name="state" type="text" value="" />
                        <div class="field-validation-valid" data-valmsg-for="state" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="ZipCode">ZIP *</label> <input class="form-control" data-val="true" data-val-required="Please enter a valid ZIP." id="ZipCode" name="ZipCode" type="text" value="" />
                        <div class="field-validation-valid" data-valmsg-for="ZipCode" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastAddress">Last address</label> <input class="form-control" id="lastAddress" name="lastAddress" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastAddress" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastCity">City</label> <input class="form-control" id="lastCity" name="lastCity" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastCity" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastState">State</label> <input class="form-control" id="lastState" name="lastState" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastState" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastZipCode">ZIP</label> <input class="form-control" id="lastZipCode" name="lastZipCode" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastZipCode" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <div class="row">
                            <div class="col-xl-5 col-lg-5 col-md-5">
                                <label>Are you legally authorized to work in the U.S.?*</label> 
                            </div>

                            <div class="col-xl-9 col-lg-9 col-md-9">
                            <label class="radio-inline mr-4"><input checked="checked" name="legalInUSA" type="radio" value="Yes" /> Yes </label> 
                            <label class="radio-inline"> <input name="legalInUSA" type="radio" value="No" /> No </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <div class="row">
                            <div class="col-xl-5 col-lg-5 col-md-5">
                                <label>Are you currently employed?*</label> 
                            </div>

                            <div class="col-xl-9 col-lg-9 col-md-9">
                                <label class="radio-inline mr-4"><input checked="checked" name="currentlyEmployed" type="radio" value="Yes" /> Yes </label>
                                <label class="radio-inline"> <input name="currentlyEmployed" type="radio" value="No" /> No </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <div class="row">
                            <div class="col-xl-5 col-lg-5 col-md-5">
                                <label>If yes, may we contact your employer?*</label> 
                            </div>

                            <div class="col-xl-9 col-lg-9 col-md-9">
                                <label class="radio-inline mr-4"><input checked="checked" name="canContactYouEmployer" type="radio" value="Yes" /> Yes </label> 
                                <label class="radio-inline"> <input name="canContactYouEmployer" type="radio" value="No" /> No </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <hr class="hr-divide" />
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <h4>Employment Desired</h4>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="currentlyEmploymentPosition">Position</label> <input class="form-control" id="currentlyEmploymentPosition" name="currentlyEmploymentPosition" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="currentlyEmploymentPosition" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="salaryDesired">Salary desired</label> <input class="form-control" id="salaryDesired" name="salaryDesired" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="salaryDesired" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="startDate">Date you can start</label>

                        <div class="form-group"><input class="form-control" id="startDate" name="startDate" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="startDate" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">&nbsp;</div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <div class="row">
                            <div class="col-xl-5 col-lg-5 col-md-5">
                                <label>Ever apply to City Glass Company before?*</label>                               
                            </div>

                            <div class="col-xl-9 col-lg-9 col-md-9">
                            <label class="radio-inline mr-4"><input checked="checked" name="applyBefore" type="radio" value="Yes" /> Yes </label> 
                            <label class="radio-inline"> <input name="applyBefore" type="radio" value="No" /> No </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <div class="row">
                            <div class="col-xl-5 col-lg-5 col-md-5">
                                <label>Ever work for City Glass Company before?* </label>
                            </div>

                            <div class="col-xl-9 col-lg-9 col-md-9">
                            <label class="radio-inline mr-4"><input checked="checked" name="workBefore" type="radio" value="Yes" /> Yes </label> 
                            <label class="radio-inline"> <input name="workBefore" type="radio" value="No" /> No </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="joinDate">If yes, when</label>

                        <div class="form-group"><input class="form-control" id="joinDate" name="joinDate" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="joinDate" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastSupervisorName">Name of last City Glass supervisor</label> <input class="form-control" id="lastSupervisorName" name="lastSupervisorName" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastSupervisorName" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <label for="reasonForLeave">Reason for leaving City Glass</label><textarea class="form-control" id="reasonForLeave" name="reasonForLeave"></textarea>

                        <div class="field-validation-valid" data-valmsg-for="reasonForLeave" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <hr class="hr-divide" />
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <h4>Education History</h4>
                    </div>

                    <div class="col-xl-4 col-lg-4 col-md-4 mb-4">
                        <label for="highSchoolName">High school</label> <input class="form-control" id="highSchoolName" name="highSchoolName" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="highSchoolName" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-4 col-lg-4 col-md-4 mb-4">
                        <label for="collegeName">College</label> <input class="form-control" id="collegeName" name="collegeName" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="collegeName" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-4 col-lg-4 col-md-4 mb-4">
                        <label for="tradeBusinessSchoolName">Trade or business school</label> <input class="form-control" id="tradeBusinessSchoolName" name="tradeBusinessSchoolName" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="tradeBusinessSchoolName" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <hr class="hr-divide" />
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <h4>General Information</h4>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <label for="specialStudyResearchWork">Subject of special study/research work</label><textarea class="form-control" id="specialStudyResearchWork" name="specialStudyResearchWork"></textarea>

                        <div class="field-validation-valid" data-valmsg-for="specialStudyResearchWork" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <label for="specialTrainingCertificationsLicenses">Special training, certifications, licenses</label><textarea class="form-control" id="specialTrainingCertificationsLicenses" name="specialTrainingCertificationsLicenses"></textarea>

                        <div class="field-validation-valid" data-valmsg-for="specialTrainingCertificationsLicenses" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <label for="specialSkillsLanguages">Special skills, foreign languages, etc...</label><textarea class="form-control" id="specialSkillsLanguages" name="specialSkillsLanguages"></textarea>

                        <div class="field-validation-valid" data-valmsg-for="specialSkillsLanguages" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <hr class="hr-divide" />
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <h4>Military Service Record</h4>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <div class="row">
                            <div class="col-xl-4 col-lg-4 col-md-4">
                                <label>Have you ever served in the U.S. Armed Forces?*</label> 
                            </div>

                            <div class="col-xl-9 col-lg-9 col-md-9">
                            <label class="radio-inline mr-4"><input checked="checked" name="militaryServiceRecord" type="radio" value="Yes"/> Yes </label> 
                            <label class="radio-inline"> <input name="militaryServiceRecord" type="radio" value="No"/> No </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <hr class="hr-divide" />
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <h4>Former Employers (chronologically list last three employers)</h4>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerNameOne">Name of Present or Last Employer</label> <input class="form-control" id="lastEmployerNameOne" name="lastEmployerNameOne" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerNameOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerJobTitleOne">Job Title</label> <input class="form-control" id="lastEmployerJobTitleOne" name="lastEmployerJobTitleOne" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerJobTitleOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerEmailAddressOne">Employer Email</label> <input class="form-control" id="lastEmployerEmailAddressOne" name="lastEmployerEmailAddressOne" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerEmailAddressOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerAddressOne">Employer Address</label> <input class="form-control" id="lastEmployerAddressOne" name="lastEmployerAddressOne" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerAddressOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerCityOne">City</label> <input class="form-control" id="lastEmployerCityOne" name="lastEmployerCityOne" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerCityOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerStateOne">State</label> <input class="form-control" id="lastEmployerStateOne" name="lastEmployerStateOne" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerStateOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerZipCodeOne">ZIP</label> <input class="form-control" id="lastEmployerZipCodeOne" name="lastEmployerZipCodeOne" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerZipCodeOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerStartDateOne">Starting Date</label>

                        <div class="form-group"><input class="form-control" id="lastEmployerStartDateOne" name="lastEmployerStartDateOne" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="lastEmployerStartDateOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerLeaveDateOne">Leaving Date</label>

                        <div class="form-group"><input class="form-control" id="lastEmployerLeaveDateOne" name="lastEmployerLeaveDateOne" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="lastEmployerLeaveDateOne" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <hr class="hr-divide" />
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerNameTwo">Name of Previous Employer</label> <input class="form-control" id="lastEmployerNameTwo" name="lastEmployerNameTwo" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerNameTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerJobTitleTwo">Job Title</label> <input class="form-control" id="lastEmployerJobTitleTwo" name="lastEmployerJobTitleTwo" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerJobTitleTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerEmailAddressTwo">Employer Email</label> <input class="form-control" id="lastEmployerEmailAddressTwo" name="lastEmployerEmailAddressTwo" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerEmailAddressTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerAddressTwo">Employer Address</label> <input class="form-control" id="lastEmployerAddressTwo" name="lastEmployerAddressTwo" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerAddressTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerCityTwo">City</label> <input class="form-control" id="lastEmployerCityTwo" name="lastEmployerCityTwo" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerCityTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerStateTwo">State</label> <input class="form-control" id="lastEmployerStateTwo" name="lastEmployerStateTwo" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerStateTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerZipCodeTwo">ZIP</label> <input class="form-control" id="lastEmployerZipCodeTwo" name="lastEmployerZipCodeTwo" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerZipCodeTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerStartDateTwo">Starting Date</label>

                        <div class="form-group"><input class="form-control" id="lastEmployerStartDateTwo" name="lastEmployerStartDateTwo" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="lastEmployerStartDateTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerLeaveDateTwo">Leaving Date</label>

                        <div class="form-group"><input class="form-control" id="lastEmployerLeaveDateTwo" name="lastEmployerLeaveDateTwo" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="lastEmployerLeaveDateTwo" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <hr class="hr-divide" />
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerNameThree">Name of Previous Employer</label> <input class="form-control" id="lastEmployerNameThree" name="lastEmployerNameThree" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerNameThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerJobTitleThree">Job Title</label> <input class="form-control" id="lastEmployerJobTitleThree" name="lastEmployerJobTitleThree" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerJobTitleThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerEmailAddressThree">Employer Email</label> <input class="form-control" id="lastEmployerEmailAddressThree" name="lastEmployerEmailAddressThree" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerEmailAddressThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerAddressThree">Employer Address</label> <input class="form-control" id="lastEmployerAddressThree" name="lastEmployerAddressThree" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerAddressThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerCityThree">City</label> <input class="form-control" id="lastEmployerCityThree" name="lastEmployerCityThree" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerCityThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerStateThree">State</label> <input class="form-control" id="lastEmployerStateThree" name="lastEmployerStateThree" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerStateThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerZipCodeThree">ZIP</label> <input class="form-control" id="lastEmployerZipCodeThree" name="lastEmployerZipCodeThree" type="text" />
                        <div class="field-validation-valid" data-valmsg-for="lastEmployerZipCodeThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerStartDateThree">Starting Date</label>

                        <div class="form-group"><input class="form-control" id="lastEmployerStartDateThree" name="lastEmployerStartDateThree" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="lastEmployerStartDateThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 mb-4">
                        <label for="lastEmployerLeaveDateThree">Leaving Date</label>

                        <div class="form-group"><input class="form-control" id="lastEmployerLeaveDateThree" name="lastEmployerLeaveDateThree" type="text" /></div>

                        <div class="field-validation-valid" data-valmsg-for="lastEmployerLeaveDateThree" data-valmsg-replace="true">&nbsp;</div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 mb-4">
                        <div class="row">
                            <div class="col-xl-12 col-lg-12 col-md-12"><label>How did you find out about this position?*</label></div>

                            <div class="col-xl-12 col-lg-12 col-md-12">
                                <label class="radio-inline mr-4"> <input  name="knowAboutThisPosition" checked="checked" type="radio" value="Employment Agency" /> Employment Agency </label>
                                <label class="radio-inline mr-4"> <input name="knowAboutThisPosition" type="radio" value="State Employment Office" /> State Employment Office </label> 
                                <label class="radio-inline mr-4"> <input name="knowAboutThisPosition" type="radio" value="Newspaper" /> Newspaper </label> 
                                <label class="radio-inline mr-4"> <input name="knowAboutThisPosition" type="radio" value="College Placement" /> College Placement </label> 
                                <label class="radio-inline mr-4"> <input name="knowAboutThisPosition" type="radio" value="Friend" /> Friend </label> 
                                <label class="radio-inline mr-4"> <input name="knowAboutThisPosition" type="radio" value="Walk-in" /> Walk-in </label>
                                <label class="radio-inline mr-4"> <input name="knowAboutThisPosition" type="radio" value="Online Ad" /> Online Ad </label>
                                <label class="radio-inline mr-4"> <input name="knowAboutThisPosition" type="radio" value="Website" /> Website </label> 
                                <label class="radio-inline"> <input name="knowAboutThisPosition" type="radio" value="Other" /> Other </label> 
                                
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 d-flex mt-4"><input id="country" name="country" type="hidden" value="United States" /><button class="btn btn-yellow" name="submit" style="padding: 5px 20px !important;" type="submit">Send</button></div>
                </div>
            </form>
        </div>
    </section>
    <!-- End Employment Application Section -->

    <section class="bg-primary p-0 hpx-100">
        <div class="container">
            <div class="row">
                <div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="/upload/2021/4/bbb_logo.png" /> </a></div>
            </div>
        </div>
    </section>

    <section class="bg-gray" id="contactuslink">
        <div class="container p-2">
            <div class="row">
                <div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
            </div>
        </div>
    </section>
</main><!-- End #main -->
', CAST(N'2021-04-09T03:48:41.143' AS DateTime), 1)
GO
INSERT [dbo].[Page] ([Id], [Name], [Url], [MetaTitle], [MetaKeyword], [MetaDescription], [Description], [AddedOn], [Status]) VALUES (14, N'Application Success', N'employment/applicationsuccess', N'Application Success', NULL, NULL, N'<main class="mt-4" id="main"> <!-- ======= Section ======= -->
<section>
<div class="container">
<div class="row">
<div class="col-md-12">
<div class="card">
<div class="card-body">
<div class="alert alert-success">Employment Application Saved Successfully.</div>
</div>
</div>
</div>
</div>
</div>
</section>
<!-- End Section -->

<section class="bg-primary p-0 hpx-100">
<div class="container">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center hpx-100 p-3"><a class="h-100" href="https://www.bbb.org/us/co/colorado-springs/profile/window-glass/city-glass-company-inc-0785-63428912" target="_blank"><img class="lazy img-fluid h-100" data-src="/upload/2021/4/bbb_logo.png" /> </a></div>
</div>
</div>
</section>

<section class="bg-gray" id="contactuslink">
<div class="container p-2">
<div class="row">
<div class="col-12 d-flex justify-content-center align-items-center"><a class="link-btn btn-yellow-xl" href="/contact"><span class="link-btn-label">Contact Us</span> </a></div>
</div>
</div>
</section>
</main><!-- End #main -->', CAST(N'2021-04-09T03:48:41.160' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Page] OFF
GO
SET IDENTITY_INSERT [dbo].[SiteInfo] ON 
GO
INSERT [dbo].[SiteInfo] ([Id], [SiteTitle], [SiteDescription], [SiteKeywords], [SiteAuthor], [SiteCanonicalUrl], [SiteShortlinkUrl], [SiteUrl], [SiteImageUrl], [SiteName], [SitePhoneNumber], [SiteOfficeNumber], [SiteLogoUrl], [SiteFavicon16X16Url], [SiteFavicon32X32Url], [SiteFavicon180x180Url], [SiteFavicon192x192Url], [AddedOn]) VALUES (1, N'City Glass Company', N'Colorado Springs most reliable glass company for mirrors, showers, windows, storefronts and more! City Glass Company provides home glass repair and many other services to ensure you have the look and feel that you want in the place you call home.', N'Colorado Springs most reliable glass company for mirrors, showers, windows, storefronts and more, city glass, best glass, bathroom frameless mirror,frameless shower,frameless shower door,frameless shower door for tub,frameless shower enclosure,frameless glass shower panel,frameless shower door hardware, windshield installation & repair in colorado springs, glass repair near me colorado,co, city glass phone number, glass, glass company, mirrors, showers, door, glass colorado springs, shower door, shower door glass, shower door glass colorado springs, windows glass, storefronts, colorado springs, glass company, city glass, city glass colorado springs, city glass company, city glass company colorado springs, plexiglass colorado springs, city glass in colorado springs, glass colorado springs, city glass colorado springs colorado, glass company colorado springs, glass replacement, colorado springs, colorado springs glass, cityglass, emergency glass repair, shower door repair, glass table tops, glass shops near me, colorado springs window repair, glass company, window glass replacement colorado springs, custom glass colorado springs, city glass co, commercial doors colorado springs, glass and mirror, coty glass, glass companies near me, glass near me, broken window glass repair, city glass & mirror, glass cuts near me, glass business doors, glass vendor, glass co. near me, glass colorado springs', N'http://placovu.com/', N'https://www.cityglasscompany.net/', N'https://www.cityglasscompany.net/', N'https://www.cityglasscompany.net/', N'https://www.cityglasscompany.net/upload/logo/favicon-192x192.png', N'City Glass', N'01911-000000', N'01911-000000', N'upload/logo/logo.png', N'upload/logo/favicon-16x16.png', N'upload/logo/favicon-32x32.png', N'upload/logo/favicon-180x180.png', N'upload/logo/favicon-192x192.png', CAST(N'2021-04-07T08:52:26.580' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SiteInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[SocialMediaConfig] ON 
GO
INSERT [dbo].[SocialMediaConfig] ([Id], [FacebookUrl], [LinkedInUrl], [InstagramUrl], [TwitterUrl], [TumblrUrl], [YouTubeUrl]) VALUES (1, N'https://www.facebook.com/cityglasscompany/', N'https://www.linkedin.com/company/city-glass-company/', N'https://www.instagram.com/cityglasscompany/', N'https://twitter.com/CityGlassCS/', N'', N'https://www.youtube.com/channel/UCfwZn0-eGe72Aj96cnfg9mw/')
GO
SET IDENTITY_INSERT [dbo].[SocialMediaConfig] OFF
GO
