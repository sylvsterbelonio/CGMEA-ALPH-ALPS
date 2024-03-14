Imports System.IO
Imports MySql.Data.MySqlClient

Namespace Member

    Public Class Member

#Region "Class Member Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritMemberNo As String
        Private CritMemberName As String
        Private CritlguName As String
        Private CritDepartmentName As String

        Private intChildCount As Integer
        Private intParentCount As Integer
        Private dtCheck1 As DataSet
        Private dtCheck2 As DataSet
        Private dtRowCheck1 As DataRow
        Private dtRowCheck2 As DataRow
        Private dtRecord As DataTable

        Private memberId As Integer
        Private memberNo As String
        Private lguId As Integer
        Private lguName As String
        Private departmentId As Integer
        Private departmentName As String
        Private referralId As Integer
        Private referralName As String
        Private lastName As String
        Private firstName As String
        Private middleName As String
        Private jobDescription As String
        Private memberPhoto As String
        Private memberBirthdate As String
        Private tempmemberBirthdate As Date
        Private memberGender As String
        Private maritalStatus As String
        Private homeTel As String
        Private workTel As String
        Private mobileNo As String
        Private emailAddress As String
        Private employeeId As String
        Private homeAddress As String
        Private rCode As String
        Private pCode As String
        Private mCode As String
        Private rurCode As String
        Private zipCodeId As Integer
        Private taxIdNo As String
        Private sssNo As String
        Private hiredFl As Integer
        Private dateHired As String
        Private tempdateHired As Date
        Private activeFl As Integer
        Private memberFl As Integer
        Private reassignFl As Integer
        Private replaceFl As Integer
        Private retireFl As Integer
        Private memberBirthPlace As String
        Private memberCitizenship As String
        Private memberHeight As String
        Private memberWeight As String
        Private memberBloodType As String
        Private pagibigIDNo As String
        Private philHealthNo As String
        Private suffixName As String
        Private updatedBy As Integer
        Private updatedDt As String
        Private birthFl As Integer
        Private appointmentStatus As String
        Private memberQualification As String
        Private salaryAmount As Double
        Private appointmentFl As Integer
        Private appointmentDt As String
        Private tempAppointmentDt As Date
        Private oathFl As Integer
        Private oathDt As String
        Private tempOathDt As Date

        Private cgmeaMembershipFl As Integer
        Private cgmeaMembershipDt As String
        Private tempCgmeaMembershipDt As Date

        Dim clsEducationalBackground As New MemberEducationalBackground.MemberEducationalBackground
        Dim strEducationalBackground As String
        Private colEducationalBackground As New Collection

        Dim clsEmploymentHistory As New MemberEmploymentHistory.MemberEmploymentHistory
        Dim strEmploymentHistory As String
        Private colEmploymentHistory As New Collection

        Dim clsOrganizations As New MemberOrganizations.MemberOrganizations
        Dim strOrganizations As String
        Private colOrganizations As New Collection

        Dim clsSeminarsAttended As New MemberSeminarsAttended.MemberSeminarsAttended
        Dim strSeminarsAttended As String
        Private colSeminarsAttended As New Collection

        Dim clsFamilyBackground As New MemberFamilyBackground.MemberFamilyBackground
        Dim strFamilyBackground As String
        Private colFamilyBackground As New Collection

        Dim clsChildren As New MemberChildren.MemberChildren
        Dim strChildren As String
        Private colChildren As New Collection

        Dim clsOtherBeneficiary As New MemberOtherBeneficiary.MemberOtherBeneficiary
        Dim strOtherBeneficiary As String
        Private colOtherBeneficiary As New Collection

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private FileSize As UInt32
        Private rawData() As Byte
        Private fs As FileStream

#End Region

#Region "Class Member Public Property Variable Declaration"

        Public WriteOnly Property Init_Flag() As Integer
            Set(ByVal Value As Integer)
                If initFlag = Value Then
                    Return
                End If
                initFlag = Value
            End Set
        End Property

        Public WriteOnly Property Dt_gRID() As DataTable
            Set(ByVal Value As DataTable)
                dtgRID = Value
            End Set
        End Property

        Public Property CritMember_No() As String
            Get
                Return CritMemberNo
            End Get
            Set(ByVal value As String)
                If CritMemberNo = value Then
                    Return
                End If
                CritMemberNo = value
            End Set
        End Property

        Public WriteOnly Property CritMember_Name() As String
            Set(ByVal Value As String)
                If CritMemberName = Value Then
                    Return
                End If
                CritMemberName = Value
            End Set
        End Property

        Public WriteOnly Property Critlgu_Name() As String
            Set(ByVal Value As String)
                If CritlguName = Value Then
                    Return
                End If
                CritlguName = Value
            End Set
        End Property

        Public WriteOnly Property CritDepartment_Name() As String
            Set(ByVal Value As String)
                If CritDepartmentName = Value Then
                    Return
                End If
                CritDepartmentName = Value
            End Set
        End Property

        Public ReadOnly Property intChild_Count() As Integer
            Get
                Return intChildCount
            End Get
        End Property

        Public ReadOnly Property intParent_Count() As Integer
            Get
                Return intParentCount
            End Get
        End Property

        Public Property Member_Id() As Integer
            Get
                Return memberId
            End Get
            Set(ByVal value As Integer)
                If memberId = value Then
                    Return
                End If
                memberId = value
            End Set
        End Property

        Public Property Member_No() As String
            Get
                Return memberNo
            End Get
            Set(ByVal value As String)
                If memberNo = value Then
                    Return
                End If
                memberNo = value
            End Set
        End Property

        Public Property lgu_Id() As Integer
            Get
                Return lguId
            End Get
            Set(ByVal value As Integer)
                If lguId = value Then
                    Return
                End If
                lguId = value
            End Set
        End Property

        Public Property lgu_Name() As String
            Get
                Return lguName
            End Get
            Set(ByVal Value As String)
                If lguName = Value Then
                    Return
                End If
                lguName = Value
            End Set
        End Property

        Public Property Department_Id() As Integer
            Get
                Return departmentId
            End Get
            Set(ByVal value As Integer)
                If departmentId = value Then
                    Return
                End If
                departmentId = value
            End Set
        End Property

        Public Property Department_Name() As String
            Get
                Return departmentName
            End Get
            Set(ByVal Value As String)
                If departmentName = Value Then
                    Return
                End If
                departmentName = Value
            End Set
        End Property

        Public Property Referral_Id() As Integer
            Get
                Return referralId
            End Get
            Set(ByVal value As Integer)
                If referralId = value Then
                    Return
                End If
                referralId = value
            End Set
        End Property

        Public ReadOnly Property Referral_Name() As String
            Get
                Return referralName
            End Get
        End Property

        <CLSCompliant(False)> _
        Public Property _suffixName() As String
            Get
                Return suffixName
            End Get
            Set(ByVal value As String)
                If suffixName = value Then
                    Return
                End If
                suffixName = value
            End Set
        End Property

        Public Property Last_Name() As String
            Get
                Return lastName
            End Get
            Set(ByVal value As String)
                If lastName = value Then
                    Return
                End If
                lastName = value
            End Set
        End Property

        Public Property First_Name() As String
            Get
                Return firstName
            End Get
            Set(ByVal value As String)
                If firstName = value Then
                    Return
                End If
                firstName = value
            End Set
        End Property

        Public Property Middle_Name() As String
            Get
                Return middleName
            End Get
            Set(ByVal value As String)
                If middleName = value Then
                    Return
                End If
                middleName = value
            End Set
        End Property

        Public Property Job_Description() As String
            Get
                Return jobDescription
            End Get
            Set(ByVal value As String)
                If jobDescription = value Then
                    Return
                End If
                jobDescription = value
            End Set
        End Property

        Public Property Appointment_Status() As String
            Get
                Return appointmentStatus
            End Get
            Set(ByVal value As String)
                If appointmentStatus = value Then
                    Return
                End If
                appointmentStatus = value
            End Set
        End Property

        Public Property Member_Qualification() As String
            Get
                Return memberQualification
            End Get
            Set(ByVal value As String)
                If memberQualification = value Then
                    Return
                End If
                memberQualification = value
            End Set
        End Property

        Public Property Salary_Amount() As Double
            Get
                Return salaryAmount
            End Get
            Set(ByVal value As Double)
                If salaryAmount = value Then
                    Return
                End If
                salaryAmount = value
            End Set
        End Property

        Public Property Member_Photo() As String
            Get
                Return memberPhoto
            End Get
            Set(ByVal value As String)
                If memberPhoto = value Then
                    Return
                End If
                memberPhoto = value
            End Set
        End Property

        Public Property Member_Birthdate() As Date
            Get
                Return memberBirthdate
            End Get
            Set(ByVal value As Date)
                If memberBirthdate = value Then
                    Return
                End If
                memberBirthdate = value
            End Set
        End Property

        Public Property TempmemberBirth_Date() As Date
            Get
                Return tempmemberBirthdate
            End Get
            Set(ByVal value As Date)
                If tempmemberBirthdate = value Then
                    Return
                End If
                tempmemberBirthdate = value
            End Set
        End Property

        Public Property Member_Gender() As String
            Get
                Return memberGender
            End Get
            Set(ByVal value As String)
                If memberGender = value Then
                    Return
                End If
                memberGender = value
            End Set
        End Property

        Public Property Marital_Status() As String
            Get
                Return maritalStatus
            End Get
            Set(ByVal value As String)
                If maritalStatus = value Then
                    Return
                End If
                maritalStatus = value
            End Set
        End Property

        Public Property Home_Tel() As String
            Get
                Return homeTel
            End Get
            Set(ByVal value As String)
                If homeTel = value Then
                    Return
                End If
                homeTel = value
            End Set
        End Property

        Public Property Work_Tel() As String
            Get
                Return workTel
            End Get
            Set(ByVal value As String)
                If workTel = value Then
                    Return
                End If
                workTel = value
            End Set
        End Property

        Public Property Mobile_No() As String
            Get
                Return mobileNo
            End Get
            Set(ByVal value As String)
                If mobileNo = value Then
                    Return
                End If
                mobileNo = value
            End Set
        End Property

        Public Property Email_Address() As String
            Get
                Return emailAddress
            End Get
            Set(ByVal value As String)
                If emailAddress = value Then
                    Return
                End If
                emailAddress = value
            End Set
        End Property

        Public Property Employee_Id() As String
            Get
                Return employeeId
            End Get
            Set(ByVal value As String)
                If employeeId = value Then
                    Return
                End If
                employeeId = value
            End Set
        End Property

        Public Property Home_Address() As String
            Get
                Return homeAddress
            End Get
            Set(ByVal value As String)
                If homeAddress = value Then
                    Return
                End If
                homeAddress = value
            End Set
        End Property

        Public Property R_Code() As String
            Get
                Return rCode
            End Get
            Set(ByVal value As String)
                If rCode = value Then
                    Return
                End If
                rCode = value
            End Set
        End Property

        Public Property P_Code() As String
            Get
                Return pCode
            End Get
            Set(ByVal value As String)
                If pCode = value Then
                    Return
                End If
                pCode = value
            End Set
        End Property

        Public Property M_Code() As String
            Get
                Return mCode
            End Get
            Set(ByVal value As String)
                If mCode = value Then
                    Return
                End If
                mCode = value
            End Set
        End Property

        Public Property Rur_Code() As String
            Get
                Return rurCode
            End Get
            Set(ByVal value As String)
                If rurCode = value Then
                    Return
                End If
                rurCode = value
            End Set
        End Property

        Public Property Zip_CodeId() As Integer
            Get
                Return zipCodeId
            End Get
            Set(ByVal value As Integer)
                If zipCodeId = value Then
                    Return
                End If
                zipCodeId = value
            End Set
        End Property

        Public Property Tax_IdNo() As String
            Get
                Return taxIdNo
            End Get
            Set(ByVal value As String)
                If taxIdNo = value Then
                    Return
                End If
                taxIdNo = value
            End Set
        End Property

        Public Property Sss_No() As String
            Get
                Return sssNo
            End Get
            Set(ByVal value As String)
                If sssNo = value Then
                    Return
                End If
                sssNo = value
            End Set
        End Property

        Public Property Date_Hired() As String
            Get
                Return dateHired
            End Get
            Set(ByVal value As String)
                If dateHired = value Then
                    Return
                End If
                dateHired = value
            End Set
        End Property

        Public Property Tempdate_Hired() As Date
            Get
                Return tempdateHired
            End Get
            Set(ByVal value As Date)
                If tempdateHired = value Then
                    Return
                End If
                tempdateHired = value
            End Set
        End Property

        Public Property Active_Fl() As Integer
            Get
                Return activeFl
            End Get
            Set(ByVal value As Integer)
                If activeFl = value Then
                    Return
                End If
                activeFl = value
            End Set
        End Property

        Public Property Member_Fl() As Integer
            Get
                Return memberFl
            End Get
            Set(ByVal value As Integer)
                If memberFl = value Then
                    Return
                End If
                memberFl = value
            End Set
        End Property

        Public Property reassign_Fl() As Integer
            Get
                Return reassignFl
            End Get
            Set(ByVal value As Integer)
                If reassignFl = value Then
                    Return
                End If
                reassignFl = value
            End Set
        End Property

        Public Property replace_Fl() As Integer
            Get
                Return replaceFl
            End Get
            Set(ByVal value As Integer)
                If replaceFl = value Then
                    Return
                End If
                replaceFl = value
            End Set
        End Property

        Public Property retire_Fl() As Integer
            Get
                Return retireFl
            End Get
            Set(ByVal value As Integer)
                If retireFl = value Then
                    Return
                End If
                retireFl = value
            End Set
        End Property

        Public Property Hired_Fl() As Integer
            Get
                Return hiredFl
            End Get
            Set(ByVal value As Integer)
                If hiredFl = value Then
                    Return
                End If
                hiredFl = value
            End Set
        End Property

        Public Property Birth_Fl() As Integer
            Get
                Return birthFl
            End Get
            Set(ByVal value As Integer)
                If birthFl = value Then
                    Return
                End If
                birthFl = value
            End Set
        End Property

        Public Property MemberBirth_Place() As String
            Get
                Return memberBirthPlace
            End Get
            Set(ByVal value As String)
                If memberBirthPlace = value Then
                    Return
                End If
                memberBirthPlace = value
            End Set
        End Property

        Public Property Member_Citizenship() As String
            Get
                Return memberCitizenship
            End Get
            Set(ByVal value As String)
                If memberCitizenship = value Then
                    Return
                End If
                memberCitizenship = value
            End Set
        End Property

        Public Property Member_Height() As String
            Get
                Return memberHeight
            End Get
            Set(ByVal value As String)
                If memberHeight = value Then
                    Return
                End If
                memberHeight = value
            End Set
        End Property

        Public Property Member_Weight() As String
            Get
                Return memberWeight
            End Get
            Set(ByVal value As String)
                If memberWeight = value Then
                    Return
                End If
                memberWeight = value
            End Set
        End Property

        Public Property MemberBlood_Type() As String
            Get
                Return memberBloodType
            End Get
            Set(ByVal value As String)
                If memberBloodType = value Then
                    Return
                End If
                memberBloodType = value
            End Set
        End Property

        Public Property PagibigID_No() As String
            Get
                Return pagibigIDNo
            End Get
            Set(ByVal value As String)
                If pagibigIDNo = value Then
                    Return
                End If
                pagibigIDNo = value
            End Set
        End Property

        Public Property PhilHealth_No() As String
            Get
                Return philHealthNo
            End Get
            Set(ByVal value As String)
                If philHealthNo = value Then
                    Return
                End If
                philHealthNo = value
            End Set
        End Property

        Public Property Appointment_Fl() As Integer
            Get
                Return appointmentFl
            End Get
            Set(ByVal value As Integer)
                If appointmentFl = value Then
                    Return
                End If
                appointmentFl = value
            End Set
        End Property

        Public Property Appointment_Dt() As String
            Get
                Return appointmentDt
            End Get
            Set(ByVal value As String)
                If appointmentDt = value Then
                    Return
                End If
                appointmentDt = value
            End Set
        End Property

        Public Property TempAppointment_Dt() As Date
            Get
                Return tempAppointmentDt
            End Get
            Set(ByVal value As Date)
                If tempAppointmentDt = value Then
                    Return
                End If
                tempAppointmentDt = value
            End Set
        End Property

        Public Property Oath_Fl() As Integer
            Get
                Return oathFl
            End Get
            Set(ByVal value As Integer)
                If oathFl = value Then
                    Return
                End If
                oathFl = value
            End Set
        End Property

        Public Property Oath_Dt() As String
            Get
                Return oathDt
            End Get
            Set(ByVal value As String)
                If oathDt = value Then
                    Return
                End If
                oathDt = value
            End Set
        End Property

        Public Property TempOath_Dt() As Date
            Get
                Return tempOathDt
            End Get
            Set(ByVal value As Date)
                If tempOathDt = value Then
                    Return
                End If
                tempOathDt = value
            End Set
        End Property

        Public Property CgmeaMembership_Fl() As Integer
            Get
                Return cgmeaMembershipFl
            End Get
            Set(ByVal value As Integer)
                If cgmeaMembershipFl = value Then
                    Return
                End If
                cgmeaMembershipFl = value
            End Set
        End Property

        Public Property CgmeaMembership_Dt() As String
            Get
                Return cgmeaMembershipDt
            End Get
            Set(ByVal value As String)
                If cgmeaMembershipDt = value Then
                    Return
                End If
                cgmeaMembershipDt = value
            End Set
        End Property

        Public Property TempCgmeaMembership_Dt() As Date
            Get
                Return tempCgmeaMembershipDt
            End Get
            Set(ByVal value As Date)
                If tempCgmeaMembershipDt = value Then
                    Return
                End If
                tempCgmeaMembershipDt = value
            End Set
        End Property

        Public Property colEducational_Background() As Collection
            Get
                Return colEducationalBackground
            End Get
            Set(ByVal Value As Collection)
                If colEducationalBackground Is Value Then
                    Return
                End If
                colEducationalBackground = Value
            End Set
        End Property

        Public Property colEmployment_History() As Collection
            Get
                Return colEmploymentHistory
            End Get
            Set(ByVal Value As Collection)
                If colEmploymentHistory Is Value Then
                    Return
                End If
                colEmploymentHistory = Value
            End Set
        End Property

        Public Property col_Organizations() As Collection
            Get
                Return colOrganizations
            End Get
            Set(ByVal Value As Collection)
                If colOrganizations Is Value Then
                    Return
                End If
                colOrganizations = Value
            End Set
        End Property

        Public Property colSeminars_Attended() As Collection
            Get
                Return colSeminarsAttended
            End Get
            Set(ByVal Value As Collection)
                If colSeminarsAttended Is Value Then
                    Return
                End If
                colSeminarsAttended = Value
            End Set
        End Property

        Public Property colFamily_Background() As Collection
            Get
                Return colFamilyBackground
            End Get
            Set(ByVal Value As Collection)
                If colFamilyBackground Is Value Then
                    Return
                End If
                colFamilyBackground = Value
            End Set
        End Property

        Public Property col_Children() As Collection
            Get
                Return colChildren
            End Get
            Set(ByVal Value As Collection)
                If colChildren Is Value Then
                    Return
                End If
                colChildren = Value
            End Set
        End Property

        Public Property colOther_Beneficiary() As Collection
            Get
                Return colOtherBeneficiary
            End Get
            Set(ByVal Value As Collection)
                If colOtherBeneficiary Is Value Then
                    Return
                End If
                colOtherBeneficiary = Value
            End Set
        End Property

        Public WriteOnly Property Updated_By() As String
            Set(ByVal Value As String)
                If updatedBy = Value Then
                    Return
                End If
                updatedBy = Value
            End Set
        End Property

        Public Property Updated_Dt() As String
            Get
                Return updatedDt
            End Get
            Set(ByVal Value As String)
                If updatedDt = Value Then
                    Return
                End If
                updatedDt = Value
            End Set
        End Property

#End Region

#Region "Class Member Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()
                Build_String_Before_Saving()

                Dim pmemberId = New MySqlParameter("?pmemberId", MySqlDbType.Int64)
                Dim pmemberNo = New MySqlParameter("?pmemberNo", MySqlDbType.VarChar)
                Dim plguId = New MySqlParameter("?plguId", MySqlDbType.Int64)
                Dim pdepartmentId = New MySqlParameter("?pdepartmentId", MySqlDbType.Int64)
                Dim preferralId = New MySqlParameter("?preferralId", MySqlDbType.Int64)
                Dim pfirstName = New MySqlParameter("?pfirstName", MySqlDbType.VarChar)
                Dim pmiddleName = New MySqlParameter("?pmiddleName", MySqlDbType.VarChar)
                Dim psuffixName = New MySqlParameter("?psuffixName", MySqlDbType.VarChar)
                Dim plastName = New MySqlParameter("?plastName", MySqlDbType.VarChar)
                Dim pjobDescription = New MySqlParameter("?pjobDescription", MySqlDbType.VarChar)
                Dim pappointmentStatus = New MySqlParameter("?pappointmentStatus", MySqlDbType.VarChar)
                Dim pmemberQualification = New MySqlParameter("?pmemberQualification", MySqlDbType.VarChar)
                Dim psalaryAmount = New MySqlParameter("?psalaryAmount", MySqlDbType.Double)
                Dim pmemberPhoto = New MySqlParameter("?pmemberPhoto", MySqlDbType.LongBlob)
                Dim pbirthFl = New MySqlParameter("?pbirthFl", MySqlDbType.Int16)
                Dim pmemberBirthdate = New MySqlParameter("?pmemberBirthdate", MySqlDbType.VarChar)
                Dim pmemberGender = New MySqlParameter("?pmemberGender", MySqlDbType.VarChar)
                Dim pmaritalStatus = New MySqlParameter("?pmaritalStatus", MySqlDbType.VarChar)
                Dim phomeTel = New MySqlParameter("?phomeTel", MySqlDbType.VarChar)
                Dim pworkTel = New MySqlParameter("?pworkTel", MySqlDbType.VarChar)
                Dim pmobileNo = New MySqlParameter("?pmobileNo", MySqlDbType.VarChar)
                Dim pemailAddress = New MySqlParameter("?pemailAddress", MySqlDbType.VarChar)
                Dim pemployeeId = New MySqlParameter("?pemployeeId", MySqlDbType.VarChar)
                Dim phomeAddress = New MySqlParameter("?phomeAddress", MySqlDbType.VarChar)
                Dim prCode = New MySqlParameter("?prCode", MySqlDbType.VarChar)
                Dim ppCode = New MySqlParameter("?ppCode", MySqlDbType.VarChar)
                Dim pmCode = New MySqlParameter("?pmCode", MySqlDbType.VarChar)
                Dim prurCode = New MySqlParameter("?prurCode", MySqlDbType.VarChar)
                Dim pzipCodeId = New MySqlParameter("?pzipCodeId", MySqlDbType.Int64)
                Dim ptaxIdNo = New MySqlParameter("?ptaxIdNo", MySqlDbType.VarChar)
                Dim psssNo = New MySqlParameter("?psssNo", MySqlDbType.VarChar)
                Dim phiredFl = New MySqlParameter("?phiredFl", MySqlDbType.Int16)
                Dim pdateHired = New MySqlParameter("?pdateHired", MySqlDbType.VarChar)
                Dim pmemberBirthPlace = New MySqlParameter("?pmemberBirthPlace", MySqlDbType.VarChar)
                Dim pmemberCitizenship = New MySqlParameter("?pmemberCitizenship", MySqlDbType.VarChar)
                Dim pmemberHeight = New MySqlParameter("?pmemberHeight", MySqlDbType.VarChar)
                Dim pmemberWeight = New MySqlParameter("?pmemberWeight", MySqlDbType.VarChar)
                Dim pmemberBloodType = New MySqlParameter("?pmemberBloodType", MySqlDbType.VarChar)
                Dim ppagibigIDNo = New MySqlParameter("?ppagibigIDNo", MySqlDbType.VarChar)
                Dim pphilHealthNo = New MySqlParameter("?pphilHealthNo", MySqlDbType.VarChar)
                Dim pactiveFl = New MySqlParameter("?pactiveFl", MySqlDbType.Int16)
                Dim pmemberFl = New MySqlParameter("?pmemberFl", MySqlDbType.Int16)
                Dim pappointmentFl = New MySqlParameter("?pappointmentFl", MySqlDbType.Int16)
                Dim pappointmentDt = New MySqlParameter("?pappointmentDt", MySqlDbType.VarChar)
                Dim poathFl = New MySqlParameter("?poathFl", MySqlDbType.Int16)
                Dim poathDt = New MySqlParameter("?poathDt", MySqlDbType.VarChar)
                Dim pcgmeaMembershipFl = New MySqlParameter("?pcgmeaMembershipFl", MySqlDbType.Int16)
                Dim pcgmeaMembershipDt = New MySqlParameter("?pcgmeaMembershipDt", MySqlDbType.VarChar)
                Dim peducationalBackgroundData = New MySqlParameter("?peducationalBackgroundData", MySqlDbType.String)
                Dim pemploymentHistoryData = New MySqlParameter("?pemploymentHistoryData", MySqlDbType.String)
                Dim porganizationData = New MySqlParameter("?porganizationData", MySqlDbType.String)
                Dim pseminarsAttendedData = New MySqlParameter("?pseminarsAttendedData", MySqlDbType.String)
                Dim pfamilyBackgroundData = New MySqlParameter("?pfamilyBackgroundData", MySqlDbType.String)
                Dim pchildrenData = New MySqlParameter("?pchildrenData", MySqlDbType.String)
                Dim potherBeneficiaryData = New MySqlParameter("?potherBeneficiaryData", MySqlDbType.String)
                Dim pupdatedBy = New MySqlParameter("?pupdatedBy", MySqlDbType.Int64)
                Dim pupdatedDt = New MySqlParameter("?pupdatedDt", MySqlDbType.VarChar)

                pmemberId.Value = memberId
                pmemberNo.Value = memberNo
                plguId.Value = lguId
                pdepartmentId.Value = departmentId
                preferralId.Value = referralId
                pfirstName.Value = firstName
                pmiddleName.Value = middleName
                plastName.Value = lastName
                psuffixName.Value = suffixName
                pjobDescription.Value = jobDescription
                pappointmentStatus.Value = appointmentStatus
                pmemberQualification.Value = memberQualification
                psalaryAmount.Value = salaryAmount

                If File.Exists(memberPhoto) Then
                    fs = New FileStream(memberPhoto, FileMode.Open, FileAccess.Read)
                    FileSize = fs.Length
                    If FileSize <= 100000 Then
                        rawData = New Byte(FileSize) {}
                        fs.Read(rawData, 0, FileSize)
                        fs.Close()
                        pmemberPhoto.Value = rawData
                    Else
                        RaiseEvent MsgArrival("Image size exceeds (Max:100KB).", False)
                        Return False
                    End If

                Else
                    pmemberPhoto.Value = DBNull.Value
                End If

                pbirthFl.Value = birthFl
                pmemberBirthdate.Value = memberBirthdate
                pmemberGender.Value = memberGender
                pmaritalStatus.Value = maritalStatus
                phomeTel.Value = homeTel
                pworkTel.Value = workTel
                pmobileNo.Value = mobileNo
                pemailAddress.Value = emailAddress
                pemployeeId.Value = employeeId
                phomeAddress.Value = homeAddress
                prCode.Value = rCode
                ppCode.Value = pCode
                pmCode.Value = mCode
                prurCode.Value = rurCode
                pzipCodeId.Value = zipCodeId
                ptaxIdNo.Value = taxIdNo
                psssNo.Value = sssNo
                phiredFl.Value = hiredFl
                pdateHired.Value = dateHired
                pmemberBirthPlace.Value = memberBirthPlace
                pmemberCitizenship.Value = memberCitizenship
                pmemberHeight.Value = memberHeight
                pmemberWeight.Value = memberWeight
                pmemberBloodType.Value = memberBloodType
                ppagibigIDNo.Value = pagibigIDNo
                pphilHealthNo.Value = philHealthNo
                pactiveFl.Value = activeFl
                pmemberFl.Value = memberFl
                pappointmentFl.Value = appointmentFl
                pappointmentDt.Value = appointmentDt
                poathFl.Value = oathFl
                poathDt.Value = oathDt
                pcgmeaMembershipFl.Value = cgmeaMembershipFl
                pcgmeaMembershipDt.Value = cgmeaMembershipDt
                peducationalBackgroundData.Value = strEducationalBackground
                pemploymentHistoryData.Value = strEmploymentHistory
                porganizationData.Value = strOrganizations
                pseminarsAttendedData.Value = strSeminarsAttended
                pfamilyBackgroundData.Value = strFamilyBackground
                pchildrenData.Value = strChildren
                potherBeneficiaryData.Value = strOtherBeneficiary
                pupdatedBy.Value = updatedBy
                pupdatedDt.Value = updatedDt

                arr = New ArrayList
                arr.Add(pmemberId)
                arr.Add(pmemberNo)
                arr.Add(plguId)
                arr.Add(pdepartmentId)
                arr.Add(preferralId)
                arr.Add(pfirstName)
                arr.Add(pmiddleName)
                arr.Add(plastName)
                arr.Add(psuffixName)
                arr.Add(pjobDescription)
                arr.Add(pappointmentStatus)
                arr.Add(pmemberQualification)
                arr.Add(psalaryAmount)
                arr.Add(pmemberPhoto)
                arr.Add(pbirthFl)
                arr.Add(pmemberBirthdate)
                arr.Add(pmemberGender)
                arr.Add(pmaritalStatus)
                arr.Add(phomeTel)
                arr.Add(pworkTel)
                arr.Add(pmobileNo)
                arr.Add(pemailAddress)
                arr.Add(pemployeeId)
                arr.Add(phomeAddress)
                arr.Add(prCode)
                arr.Add(ppCode)
                arr.Add(pmCode)
                arr.Add(prurCode)
                arr.Add(pzipCodeId)
                arr.Add(ptaxIdNo)
                arr.Add(psssNo)
                arr.Add(phiredFl)
                arr.Add(pdateHired)
                arr.Add(pmemberBirthPlace)
                arr.Add(pmemberCitizenship)
                arr.Add(pmemberHeight)
                arr.Add(pmemberWeight)
                arr.Add(pmemberBloodType)
                arr.Add(ppagibigIDNo)
                arr.Add(pphilHealthNo)
                arr.Add(pactiveFl)
                arr.Add(pmemberFl)
                arr.Add(pappointmentFl)
                arr.Add(pappointmentDt)
                arr.Add(poathFl)
                arr.Add(poathDt)
                arr.Add(pcgmeaMembershipFl)
                arr.Add(pcgmeaMembershipDt)
                arr.Add(peducationalBackgroundData)
                arr.Add(pemploymentHistoryData)
                arr.Add(porganizationData)
                arr.Add(pseminarsAttendedData)
                arr.Add(pfamilyBackgroundData)
                arr.Add(pchildrenData)
                arr.Add(potherBeneficiaryData)
                arr.Add(pupdatedBy)
                arr.Add(pupdatedDt)

                Save_Record = True

                strSql = "spMemberSave"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE, arr)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        memberId = Me.dtSaveRow("memberId")
                        updatedDt = Me.dtSaveRow("updatedDt")
                    Next
                    RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Record = False
            End Try
        End Function

        Public Function Delete_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim dtRec As DataTable

                Delete_Record = True
                strSql = "CALL spMemberDelete(" & memberId & "," & updatedBy & ");"
                dtRec = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                Dim myRow As DataRow

                For Each myRow In dtRec.Rows
                    ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    RaiseEvent MsgArrival(MSGBOX_INACTIVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Delete_Record = False
            End Try
        End Function

        Public Function Search_Record()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spMemberFind(" & memberId _
                    & ",'" & CritMemberNo & "','" & CritMemberName & "','" _
                    & CritlguName & "','" & CritDepartmentName & "',0,0," & initFlag & ");"

                    dtgRID = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)

                    Dim myRow As DataRow

                    For Each myRow In dtgRID.Rows
                        ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                    Next

                    If ErrorMsg <> "" Then
                        RaiseEvent MsgArrival(ErrorMsg, False)
                        Return Nothing
                    Else
                        clsDataAccess = Nothing
                        Return dtgRID
                    End If
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function Selected_Record() As Boolean
            Dim strSql As String
            Dim ErrorMsg As String = ""
            Dim dtSelectedRecord As DataTable

            Try
                Clean_Parameters_Search()

                With clsDataAccess

                    strSql = "CALL spMemberFind(" & initFlag & ",'','','','',0,0,2);"

                    dtSelectedRecord = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)

                    Dim myRow As DataRow

                    For Each myRow In dtSelectedRecord.Rows
                        ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                    Next

                    If ErrorMsg <> "" Then
                        RaiseEvent MsgArrival(ErrorMsg, False)
                        Return False
                        Exit Function
                    End If

                    Dim myRow1 As DataRow

                    For Each myRow1 In dtSelectedRecord.Rows
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberNo = Trim(myRow1("memberNo").ToString)
                        Me.lguId = Trim(myRow1("lguId").ToString)
                        Me.lguName = Trim(myRow1("lguName").ToString)
                        Me.departmentId = Trim(myRow1("departmentId").ToString)
                        Me.departmentName = Trim(myRow1("departmentName").ToString)
                        'Me.referralId = Trim(myRow1("referralId").ToString)
                        'Me.referralName = Trim(myRow1("referralName").ToString)
                        Me.firstName = Trim(myRow1("firstName").ToString)
                        Me.middleName = Trim(myRow1("middleName").ToString)
                        Me.lastName = Trim(myRow1("lastName").ToString)
                        Me.suffixName = Trim(myRow1("suffixName").ToString)
                        Me.jobDescription = Trim(myRow1("jobDescription").ToString)
                        Me.appointmentStatus = Trim(myRow1("appointmentStatus").ToString)
                        Me.memberQualification = Trim(myRow1("memberQualification").ToString)
                        Me.salaryAmount = Trim(myRow1("salaryAmount").ToString)
                        If Not IsDBNull(myRow1("memberPhoto")) Then
                            Me.memberPhoto = ImageDir & "\" & LCase(lastName) & LCase(firstName) & LCase(middleName) & LCase(suffixName) & ".jpg"
                            Dim b() As Byte
                            Try
                                b = myRow1("memberPhoto")
                                Dim K As Long
                                K = UBound(b)

                                Dim WriteFs As New FileStream(memberPhoto, FileMode.Create, FileAccess.ReadWrite)
                                WriteFs.Write(b, 0, K)
                                WriteFs.Close()
                            Catch oExcept As Exception
                                'clsCommon.Prompt_User("error", "Error creating member image to disk :" & oExcept.Message)
                            End Try
                        Else
                            Me.memberPhoto = ""
                        End If
                        Me.birthFl = Trim(myRow1("birthFl").ToString)
                        Me.memberBirthdate = Trim(myRow1("memberBirthdate").ToString)
                        Me.tempmemberBirthdate = Microsoft.VisualBasic.DateValue(myRow1("memberBirthdate").ToString)
                        Me.memberGender = Trim(myRow1("memberGender").ToString)
                        Me.maritalStatus = Trim(myRow1("maritalStatus").ToString)
                        Me.homeTel = Trim(myRow1("homeTel").ToString)
                        Me.workTel = Trim(myRow1("workTel").ToString)
                        Me.mobileNo = Trim(myRow1("mobileNo").ToString)
                        Me.emailAddress = Trim(myRow1("emailAddress").ToString)
                        Me.employeeId = Trim(myRow1("employeeId").ToString)
                        Me.homeAddress = Trim(myRow1("homeAddress").ToString)
                        Me.rCode = Trim(myRow1("rCode").ToString)
                        Me.pCode = Trim(myRow1("pCode").ToString)
                        Me.mCode = Trim(myRow1("mCode").ToString)
                        Me.rurCode = Trim(myRow1("rurCode").ToString)
                        Me.zipCodeId = Trim(myRow1("zipCodeId").ToString)
                        Me.taxIdNo = Trim(myRow1("taxIdNo").ToString)
                        Me.sssNo = Trim(myRow1("sssNo").ToString)
                        Me.hiredFl = Trim(myRow1("hiredFl").ToString)
                        Me.dateHired = Trim(myRow1("hireDt").ToString)
                        Me.tempdateHired = Microsoft.VisualBasic.DateValue(myRow1("hireDt").ToString)
                        Me.memberBirthPlace = Trim(myRow1("memberBirthPlace").ToString)
                        Me.memberCitizenship = Trim(myRow1("memberCitizenship").ToString)
                        Me.memberHeight = Trim(myRow1("memberHeight").ToString)
                        Me.memberWeight = Trim(myRow1("memberWeight").ToString)
                        Me.memberBloodType = Trim(myRow1("memberBloodType").ToString)
                        Me.pagibigIDNo = Trim(myRow1("pagibigIDNo").ToString)
                        Me.philHealthNo = Trim(myRow1("philHealthNo").ToString)
                        Me.activeFl = Trim(myRow1("activeFl").ToString)
                        Me.memberFl = Trim(myRow1("memberFl").ToString)
                        Me.appointmentFl = Trim(myRow1("appointmentFl").ToString)
                        Me.appointmentDt = Trim(myRow1("appointmentDt").ToString)
                        Me.tempAppointmentDt = Microsoft.VisualBasic.DateValue(myRow1("appointmentDt").ToString)
                        Me.oathFl = Trim(myRow1("oathFl").ToString)
                        Me.oathDt = Trim(myRow1("oathDt").ToString)
                        Me.tempOathDt = Microsoft.VisualBasic.DateValue(myRow1("oathDt").ToString)
                        Me.cgmeaMembershipFl = Trim(myRow1("cgmeaMembershipFl").ToString)
                        Me.cgmeaMembershipDt = Trim(myRow1("cgmeaMembershipDt").ToString)
                        Me.tempCgmeaMembershipDt = Trim(myRow1("cgmeaMembershipDt").ToString)
                        Me.reassignFl = Trim(myRow1("reassignFl").ToString)
                        Me.replaceFl = Trim(myRow1("replaceFl").ToString)
                        Me.retireFl = Trim(myRow1("retireFl").ToString)
                        Me.updatedDt = Trim(myRow1("updatedDt").ToString)
                    Next

                End With
                Return True
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return False
            Finally
                dtSelectedRecord = Nothing
            End Try
        End Function

        Public Function GetLGUNames() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spLGUGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetDepartmentNames() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spDepartmentGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetJobTitles() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spMemberJobGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetAppointmentStatus() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spMemberAppointmentStatusGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetQualification() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spMemberQualificationGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetDepartmentList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spDepartmentGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetDefaultParameter(ByVal paramName As String) As String
            Dim dtParam As DataTable
            Dim sqlStmt As String
            Dim paramVal As String = ""

            Try
                sqlStmt = "CALL spDefaultParameterGet('" & paramName & "');"
                dtParam = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                If dtParam.Rows.Count <> 0 Then
                    paramVal = dtParam.Rows(0)("paramVal")
                Else
                    paramVal = ""
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
            Return paramVal
        End Function

        Public Function GetRegionList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialRegionGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetProvinceList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialProvinceGet('" & rCode & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetMunicipalityList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialMunicipalityGet('" & pCode & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetBarangayList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialBarangayGet('" & mCode & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetZipCodeList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialZipCodeGet('" & mCode & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetNewMemberNo() As Integer
            Dim sqlStmt As String
            GetNewMemberNo = 0
            Try
                sqlStmt = "CALL spMemberNoGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetNewMemberNo = dtRecord.Rows(0)("memberNo")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Populate_Record_Member() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberFind(" & initFlag & ",'','','','',0,0,2);"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Educational_Background() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberEducationalBackgroundFind(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Employment_History() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberEmploymentHistoryFind(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Member_Organization() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberOrganizationFind(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Seminars_Attended() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberSeminarsAttendedFind(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Family_Background() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberFamilyBackgroundFind(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Children() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberChildrenFind(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Children_Report() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberChildrenReport(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Record_Other_Beneficiary() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberOtherBeneficiaryFind(" & memberId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function System_User_Report() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spReportSystemUserFind(" & gUserID & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

#End Region

#Region "Class Member Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
                CritlguName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritlguName))
                CritDepartmentName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDepartmentName))
                CritMemberNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberNo))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                memberBirthdate = tempmemberBirthdate.ToString("yyyy-MM-dd")
                dateHired = tempdateHired.ToString("yyyy-MM-dd")
                appointmentDt = tempAppointmentDt.ToString("yyyy-MM-dd")
                oathDt = tempOathDt.ToString("yyyy-MM-dd")
                cgmeaMembershipDt = tempCgmeaMembershipDt.ToString("yyyy-MM-dd")

                memberNo = .ReplaceSingleQuotes(memberNo)
                lguName = .ReplaceSingleQuotes(lguName)
                departmentName = .ReplaceSingleQuotes(departmentName)
                firstName = .ReplaceSingleQuotes(firstName)
                middleName = .ReplaceSingleQuotes(middleName)
                lastName = .ReplaceSingleQuotes(lastName)
                suffixName = .ReplaceSingleQuotes(suffixName)
                homeTel = .ReplaceSingleQuotes(homeTel)
                workTel = .ReplaceSingleQuotes(workTel)
                mobileNo = .ReplaceSingleQuotes(mobileNo)
                emailAddress = .ReplaceSingleQuotes(emailAddress)
                employeeId = .ReplaceSingleQuotes(employeeId)
                homeAddress = .ReplaceSingleQuotes(homeAddress)
                rCode = .ReplaceSingleQuotes(rCode)
                pCode = .ReplaceSingleQuotes(pCode)
                mCode = .ReplaceSingleQuotes(mCode)
                rurCode = .ReplaceSingleQuotes(rurCode)
                jobDescription = .ReplaceSingleQuotes(jobDescription)
                appointmentStatus = .ReplaceSingleQuotes(appointmentStatus)
                memberQualification = .ReplaceSingleQuotes(memberQualification)
                memberBirthdate = .ReplaceSingleQuotes(memberBirthdate)
                maritalStatus = .ReplaceSingleQuotes(maritalStatus)
                memberGender = .ReplaceSingleQuotes(memberGender)
                taxIdNo = .ReplaceSingleQuotes(taxIdNo)
                sssNo = .ReplaceSingleQuotes(sssNo)
                dateHired = .ReplaceSingleQuotes(dateHired)
                memberBirthPlace = .ReplaceSingleQuotes(memberBirthPlace)
                memberCitizenship = .ReplaceSingleQuotes(memberCitizenship)
                memberHeight = .ReplaceSingleQuotes(memberHeight)
                memberWeight = .ReplaceSingleQuotes(memberWeight)
                memberBloodType = .ReplaceSingleQuotes(memberBloodType)
                pagibigIDNo = .ReplaceSingleQuotes(pagibigIDNo)
                philHealthNo = .ReplaceSingleQuotes(philHealthNo)
                appointmentDt = .ReplaceSingleQuotes(appointmentDt)
                oathDt = .ReplaceSingleQuotes(oathDt)
                cgmeaMembershipDt = .ReplaceSingleQuotes(cgmeaMembershipDt)
            End With
        End Sub

        Private Sub Build_String_Before_Saving()
            Dim clsEducationalBackground As MemberEducationalBackground.MemberEducationalBackground
            strEducationalBackground = ""

            If IsNothing(colEducationalBackground) = False Then
                For Each clsEducationalBackground In colEducationalBackground
                    strEducationalBackground += CStr(clsEducationalBackground.Educational_Level) _
                    & "|" & CStr(clsEducationalBackground.School_Name) _
                    & "|" & CStr(clsEducationalBackground.Degree_Course) _
                    & "|" & CStr(clsEducationalBackground.Higest_Grade) _
                    & "|" & CStr(clsEducationalBackground.From_Date) _
                    & "|" & CStr(clsEducationalBackground.To_Date) _
                    & "|" & CStr(clsEducationalBackground.Honors_Received) & "|"
                Next
            End If

            Dim clsEmploymentHistory As MemberEmploymentHistory.MemberEmploymentHistory
            strEmploymentHistory = ""

            If IsNothing(colEmploymentHistory) = False Then
                For Each clsEmploymentHistory In colEmploymentHistory
                    strEmploymentHistory += CStr(clsEmploymentHistory.From_Date) _
                    & "|" & CStr(clsEmploymentHistory.To_Date) _
                    & "|" & CStr(clsEmploymentHistory.Job_Title) _
                    & "|" & CStr(clsEmploymentHistory.Company_Name) _
                    & "|" & CStr(clsEmploymentHistory.Company_Address) _
                    & "|" & CStr(clsEmploymentHistory.CompanyContact_No) _
                    & "|" & CDbl(clsEmploymentHistory.Monthly_Salary) _
                    & "|" & CStr(clsEmploymentHistory.Task_Accomplishment) & "|"
                Next
            End If

            Dim clsOrganizations As MemberOrganizations.MemberOrganizations
            strOrganizations = ""

            If IsNothing(colOrganizations) = False Then
                For Each clsOrganizations In colOrganizations
                    strOrganizations += CStr(clsOrganizations.Organization_Name) _
                    & "|" & CStr(clsOrganizations.Organization_Address) _
                    & "|" & CStr(clsOrganizations.Organization_Position) _
                    & "|" & CStr(clsOrganizations.Since_Date) & "|"
                Next
            End If

            Dim clsSeminarsAttended As MemberSeminarsAttended.MemberSeminarsAttended
            strSeminarsAttended = ""

            If IsNothing(colSeminarsAttended) = False Then
                For Each clsSeminarsAttended In colSeminarsAttended
                    strSeminarsAttended += CStr(clsSeminarsAttended.Seminar_Name) _
                    & "|" & CStr(clsSeminarsAttended.Seminar_Location) _
                    & "|" & CStr(clsSeminarsAttended.Seminar_Date) _
                    & "|" & CStr(clsSeminarsAttended.Seminar_Remarks) & "|"
                Next
            End If

            Dim clsFamilyBackground As MemberFamilyBackground.MemberFamilyBackground
            strFamilyBackground = ""

            If IsNothing(colFamilyBackground) = False Then
                For Each clsFamilyBackground In colFamilyBackground
                    strFamilyBackground += CStr(clsFamilyBackground.Spouse_FName) _
                    & "|" & CStr(clsFamilyBackground.Spouse_MName) _
                    & "|" & CStr(clsFamilyBackground.Spouse_LName) _
                    & "|" & CStr(clsFamilyBackground.Spouse_Suffix) _
                    & "|" & CStr(clsFamilyBackground.Spouse_Birth) _
                    & "|" & CStr(clsFamilyBackground.Father_FName) _
                    & "|" & CStr(clsFamilyBackground.Father_MName) _
                    & "|" & CStr(clsFamilyBackground.Father_LName) _
                    & "|" & CStr(clsFamilyBackground.Father_Suffix) _
                    & "|" & CStr(clsFamilyBackground.Mother_FName) _
                    & "|" & CStr(clsFamilyBackground.Mother_MName) _
                    & "|" & CStr(clsFamilyBackground.Mother_LName) & "|"
                Next
            End If

            Dim clsChildren As MemberChildren.MemberChildren
            strChildren = ""

            If IsNothing(colChildren) = False Then
                For Each clsChildren In colChildren
                    strChildren += CStr(clsChildren.Child_FName) _
                    & "|" & CStr(clsChildren.Child_MName) _
                    & "|" & CStr(clsChildren.Child_LName) _
                    & "|" & CStr(clsChildren.Child_Suffix) _
                    & "|" & CStr(clsChildren.Child_Birth) _
                    & "|" & CStr(clsChildren.Child_Status) & "|"
                Next
            End If

            Dim clsOtherBeneficiary As MemberOtherBeneficiary.MemberOtherBeneficiary
            strOtherBeneficiary = ""

            If IsNothing(colOtherBeneficiary) = False Then
                For Each clsOtherBeneficiary In colOtherBeneficiary
                    strOtherBeneficiary += CStr(clsOtherBeneficiary.Beneficiary_FName) _
                    & "|" & CStr(clsOtherBeneficiary.Beneficiary_MName) _
                    & "|" & CStr(clsOtherBeneficiary.Beneficiary_LName) _
                    & "|" & CStr(clsOtherBeneficiary.Beneficiary_Suffix) _
                    & "|" & CStr(clsOtherBeneficiary.Beneficiary_Relation) & "|"
                Next
            End If
        End Sub

#End Region

    End Class

End Namespace
