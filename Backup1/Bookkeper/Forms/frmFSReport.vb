Imports PowerNET8.myNumber.Share.Formatter

Public Class frmFSReport

    Private WithEvents clsCommon As New Common.Common
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub initialize()
        Connect(mysql)
    End Sub

    Private Sub frmFSReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
        cboType.SelectedIndex = 0
        cboMonth.SelectedIndex = Now.Month - 1
        txtYear.Value = Now.Year
    End Sub

    Dim colTypeID As New ArrayList

    Private Sub optMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonth.CheckedChanged, optQuarter.CheckedChanged, optYear.CheckedChanged
        cboMonth.Enabled = True
        If optMonth.Checked Then
            Label3.Text = "Month"
            With cboMonth
                .Items.Clear()
                With .Items
                    .Add("Jan")
                    .Add("Feb")
                    .Add("Mar")
                    .Add("Apr")
                    .Add("May")
                    .Add("Jun")
                    .Add("Jul")
                    .Add("Aug")
                    .Add("Sep")
                    .Add("Oct")
                    .Add("Nov")
                    .Add("Dec")
                End With
            End With
            cboMonth.SelectedIndex = Now.Month - 1
        ElseIf optQuarter.Checked Then
            Label3.Text = "Qrt."
            With cboMonth
                .Items.Clear()
                With .Items
                    .Add("1st")
                    .Add("2nd")
                    .Add("3rd")
                    .Add("4th")
                End With
            End With
            cboMonth.SelectedIndex = 0
        ElseIf optYear.Checked Then
            cboMonth.Enabled = False
        End If
    End Sub

    Private Function getTable()
        Dim table As New PowerNET8.myDataTableCreator
        With table
            .new_table("tbldetails")
            .add_columnField("desc")
            .add_columnField("val1", PowerNET8.myDataTableCreator.FieldType.Decimal_)
            .add_columnField("val2", PowerNET8.myDataTableCreator.FieldType.Decimal_)
            .add_columnField("val3", PowerNET8.myDataTableCreator.FieldType.Decimal_)
            Return .get_table
        End With
    End Function

    Private Function getTableBilling()
        Dim table As New PowerNET8.myDataTableCreator
        With table
            .new_table("tblDetails")
            .add_columnField("name")
            .add_columnField("billingname")
            .add_columnField("amountDue", PowerNET8.myDataTableCreator.FieldType.Decimal_)
            Return .get_table
        End With
    End Function


    Private Function getQuarter(ByVal qtr As String)
        Select Case qtr
            Case "1st"
                Return "Jan - Mar"
            Case "2nd"
                Return "Apr - Jun"
            Case "3rd"
                Return "Jul - Sep"
            Case "4th"
                Return "Oct - Dec"
        End Select
    End Function

    Private Function getSubHeader()
        Dim con As String = ""
        If optMonth.Checked Then
            con = "For the month of "
            Return con + cboMonth.Text + ", " + txtYear.Value.ToString
        ElseIf optQuarter.Checked Then
            con = "For the quarter of "
            Return con + getQuarter(cboMonth.Text) + ", " + txtYear.Value.ToString
        Else
            Return "For the whole year of " + txtYear.Value.ToString
        End If
    End Function

    Private Function getDate() As String
        If optMonth.Checked Then
            Return "'" + txtYear.Value.ToString + "-" + (cboMonth.SelectedIndex + 1).ToString + "-1' and '" + txtYear.Value.ToString + "-" + (cboMonth.SelectedIndex + 1).ToString + "-31'"
        ElseIf optQuarter.Checked Then
            Select Case cboMonth.Text
                Case "1st"
                    Return "'" + txtYear.Value.ToString + "-1-1' and '" + txtYear.Value.ToString + "-3-31'"
                Case "2nd"
                    Return "'" + txtYear.Value.ToString + "-4-1' and '" + txtYear.Value.ToString + "-6-31'"
                Case "3rd"
                    Return "'" + txtYear.Value.ToString + "-7-1' and '" + txtYear.Value.ToString + "-9-31'"
                Case "4th"
                    Return "'" + txtYear.Value.ToString + "-10-1' and '" + txtYear.Value.ToString + "-12-31'"
            End Select
        Else
            Return "'" + txtYear.Value.ToString + "-1-1' and '" + txtYear.Value.ToString + "-12-31'"
        End If
    End Function

    Private Sub cboGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGenerate.Click
        Dim cr As New PowerNET8.myDocument.Init.CrystalReportViewer
        Dim py As New PowerNET8.myFile.Share.Location

        If cboType.Text = "Financial Statement" Then
            Dim table As DataTable = getTable()
            Dim sql As String = "SELECT tbl_expenses_group.name,`group`,sum(amount) as 'amount' FROM   tbl_expenses_group   left JOIN tbl_expenses      ON (tbl_expenses_group.name = tbl_expenses.expensesName)  where date_incurred between " + getDate() + " or amount is null  group by tbl_expenses_group.name   order by tbl_expenses_group.order"

            Dim mydata As DataTable = mysql.Query(sql)
            Dim groupName As String = ""
            Dim groupTot As Decimal = 0
            Dim grandTot As Decimal = 0
            Dim superTot As Decimal = 0

            For i As Integer = 0 To mydata.Rows.Count - 1
                With table
                    .Rows.Add()
                    With .Rows(i)
                        If mydata.Rows(i).Item("group") = "" Then
                            .Item("desc") = mydata.Rows(i).Item("name")
                            .Item("val1") = 0
                            If Not IsDBNull(mydata.Rows(i).Item("amount")) Then
                                .Item("val2") = mydata.Rows(i).Item("amount")
                                superTot += mydata.Rows(i).Item("amount")
                            Else
                                .Item("val2") = 0
                            End If
                            .Item("val3") = 0
                        Else
                            If mydata.Rows(i).Item("group") = groupName Then
                                .Item("desc") = mydata.Rows(i).Item("name")
                                If Not IsDBNull(mydata.Rows(i).Item("amount")) Then
                                    groupTot += mydata.Rows(i).Item("amount")
                                    superTot += mydata.Rows(i).Item("amount")

                                    .Item("val1") = mydata.Rows(i).Item("amount")
                                End If
                                .Item("val2") = 0
                                .Item("val3") = 0
                                If (i + 1) >= mydata.Rows.Count - 1 Then
                                    .Item("val2") = groupTot
                                    .Item("val3") = superTot
                                Else
                                    If mydata.Rows(i + 1).Item("group") = groupName Then
                                        'do nothing
                                    Else
                                        .Item("val2") = groupTot
                                    End If
                                End If
                            Else
                                groupName = mydata.Rows(i).Item("group")
                                groupTot = 0

                                .Item("desc") = mydata.Rows(i).Item("name")
                                If Not IsDBNull(mydata.Rows(i).Item("amount")) Then
                                    .Item("val1") = mydata.Rows(i).Item("amount")
                                    groupTot += mydata.Rows(i).Item("amount")
                                    superTot += mydata.Rows(i).Item("amount")
                                End If
                                .Item("val2") = 0
                                .Item("val3") = 0
                            End If
                        End If

                    End With
                End With
            Next

            With cr
                .title = "Financial Statement"
                .addTableField(table)

                .addParameterField("lblSubHeader", getSubHeader)
                .addParameterField("lblInterestIncome", format_DecimalOnly(getCollectionBilling("LOAN INTEREST"), 2))
                .addParameterField("lblMembershipFee", format_DecimalOnly(getCollectionBilling("MEMBERSHIP FEE"), 2))
                .addParameterField("lblServiceFee", format_DecimalOnly(getCollectionBilling("SERVICE FEE"), 2))
                .addParameterField("lblRebates", format_DecimalOnly(getCollectionBilling("LOAN INTEREST (REBATES)"), 2))
                Dim a As String = "Reports\rptFinancialStatement.rpt"
                .reportPath(a)
                .launchReport()
            End With
        ElseIf cboType.Text = "Collection" Then
            'BILLING
            Dim table As DataTable = getTableBilling()
            Dim cash As DataTable = getDocumentTable(tableType.cashbeginning)
            Dim totCash As Decimal = 0
            Dim totExp As Decimal = 0

            Dim mydata As DataTable = mysql.Query("SELECT tblcollectiontype.typeName,  sum(amountDue) as 'amount'  FROM  tblcollectiontype  INNER JOIN tblbilling    ON (tblcollectiontype.typeId = tblbilling.typeId) where amountDueDt between " + getDate() + " and paidFl=1 group by tblcollectiontype.typeName order by typeName")
            For i As Integer = 0 To mydata.Rows.Count - 1
                With cash
                    .Rows.Add()
                    With .Rows(i)
                        totCash += mydata.Rows(i).Item("amount")
                        .Item("desc") = mydata.Rows(i).Item("typeName")
                        .Item("amount") = format_DecimalOnly(mydata.Rows(i).Item("amount"), 2)
                    End With
                End With
            Next

            mydata = mysql.Query("SELECT `type`, sum(netProceeds) as 'amount' FROM   tbl_typeloan  INNER JOIN tblloanapplication    ON (tbl_typeloan.NoId = tblloanapplication.loanTypeId) where loanStatus = 'LOAN RELEASED' and releasedDt between " + getDate() + "  group by type  order by type")
            For i As Integer = 0 To mydata.Rows.Count - 1
                With table
                    .Rows.Add()
                    With .Rows(i)
                        .Item("name") = mydata.Rows(i).Item("type")
                        .Item("billingname") = mydata.Rows(i).Item("type")
                        .Item("amountDue") = mydata.Rows(i).Item("amount")
                    End With
                End With
                totExp += mydata.Rows(i).Item("amount")
            Next
            With cr
                .title = "COLLECTION FEE"
                .addTableField(cash)
                .addTableField(table)
                .addParameterField("lblTotCash", totCash)
                .addParameterField("lblTotExp", totExp)
                .addParameterField("lblSubHeader", "")
                .addParameterField("lblPeriod", getSubHeader)
                Dim a As String = "Reports\rptCollection.rpt"
                .reportPath(a)
                .launchReport()
            End With
        ElseIf cboType.Text = "List of Official Receipts Issued" Then
            List_of_Official_Receipts_Issued(cr)
        ElseIf cboType.Text = "List of Checks Issued" Then
            List_of_Checks_Issued(cr)
        ElseIf cboType.Text = "Balance Monitoring Report/Transaction History" Then
            Balance_Monitoring_Report_Transaction_History(cr)
        End If

    End Sub

    Private Enum tableType
        officialreceipt
        checkissued
        balancemonitoring
        cashbeginning
    End Enum
    Private Function getDocumentTable(ByVal type As tableType) As DataTable
        Dim table As New PowerNET8.myDataTableCreator
        With table
            Select Case type
                Case tableType.cashbeginning
                    .new_table("tblCashBegin")
                    .add_columnField("desc")
                    .add_columnField("amount", PowerNET8.myDataTableCreator.FieldType.Decimal_)
                Case tableType.officialreceipt
                    .new_table("tblOfficialReceipts")
                    .add_columnField("orNo")
                    .add_columnField("amount", PowerNET8.myDataTableCreator.FieldType.Decimal_)
                    .add_columnField("date")
                    .add_columnField("payee")
                    .add_columnField("voucherNo")
                    .add_columnField("remarks")
                Case tableType.checkissued
                    .new_table("tblCheckIssued")
                    .add_columnField("checkNo")
                    .add_columnField("amount", PowerNET8.myDataTableCreator.FieldType.Decimal_)
                    .add_columnField("date")
                    .add_columnField("payee")
                    .add_columnField("voucherNo")
                    .add_columnField("remarks")
                Case tableType.balancemonitoring
                    .new_table("tblBalMoRep")
                    .add_columnField("date")
                    .add_columnField("description")
                    .add_columnField("debit", PowerNET8.myDataTableCreator.FieldType.Decimal_)
                    .add_columnField("credit", PowerNET8.myDataTableCreator.FieldType.Decimal_)
                    .add_columnField("balance", PowerNET8.myDataTableCreator.FieldType.Decimal_)
                    .add_columnField("details")
                    .add_columnField("checkNo")
                    .add_columnField("VourcherNo")
            End Select
            Return .get_table
        End With
    End Function

    Private Sub Balance_Monitoring_Report_Transaction_History(ByRef cr As PowerNET8.myDocument.Init.CrystalReportViewer)
        Dim balance As Double = 100000

        Dim table As DataTable = getDocumentTable(tableType.balancemonitoring)
        Dim expenses As DataTable = mysql.Query("SELECT date_incurred, expensesName, amount, concat(firstName, ' ', middleName,' ', lastName) as 'name',frmEstablishment, checkNo,  	voucherNo  FROM  tblmember   right JOIN tbl_expenses    ON (tblmember.memberId = tbl_expenses.frmPerson) WHERE date_incurred between " + getDate() + " order by date_incurred")
        Dim count As Integer = 0
        Dim container As DataTable = getDocumentTable(tableType.balancemonitoring)
        Dim reverseContainer As DataTable = getDocumentTable(tableType.balancemonitoring)


        For i As Integer = 0 To expenses.Rows.Count - 1
            With table
                .Rows.Add()
                With .Rows(.Rows.Count - 1)
                    Dim dt As Date = expenses.Rows(i).Item("date_incurred")
                    .Item("date") = dt.ToString("MM/dd/yyyy")
                    .Item("description") = expenses.Rows(i).Item("expensesName")
                    .Item("debit") = expenses.Rows(i).Item("amount")
                    .Item("credit") = 0
                    balance -= expenses.Rows(i).Item("amount")
                    .Item("balance") = balance
                    .Item("details") = IIf(Not IsDBNull(expenses.Rows(i).Item("name")), expenses.Rows(i).Item("name"), expenses.Rows(i).Item("frmEstablishment"))
                    .Item("checkNo") = expenses.Rows(i).Item("checkNo")
                    .Item("VourcherNo") = expenses.Rows(i).Item("voucherNo")
                End With
            End With
        Next

        Dim loanApplication As DataTable = mysql.Query("SELECT releasedDt, loanStatus, netProceeds, concat(`type`,'-',   firstName,' ',middleName,' ',lastName) as 'name', checkNo,voucherNo FROM    tblmember   INNER JOIN  tblloanapplication     ON (tblmember.memberId = tblloanapplication.memberId)   INNER JOIN  tbl_typeloan    ON (tbl_typeloan.NoId = tblloanapplication.loanTypeId) where releasedFl=1 and tblloanapplication.cancelFl=0 and netProceeds>0 and  releasedDt between " + getDate() + " order by releasedDt")
        For i As Integer = 0 To loanApplication.Rows.Count - 1
            With table
                .Rows.Add()
                With .Rows(.Rows.Count - 1)
                    Dim dt As Date = loanApplication.Rows(i).Item("releasedDt")
                    .Item("date") = dt.ToString("MM/dd/yyyy")
                    .Item("description") = loanApplication.Rows(i).Item("loanStatus")
                    .Item("debit") = loanApplication.Rows(i).Item("netProceeds")
                    .Item("credit") = 0
                    balance -= loanApplication.Rows(i).Item("netProceeds")
                    .Item("balance") = balance
                    .Item("details") = loanApplication.Rows(i).Item("name")
                    .Item("checkNo") = loanApplication.Rows(i).Item("checkNo")
                    .Item("VourcherNo") = loanApplication.Rows(i).Item("voucherNo")
                End With
            End With
        Next

        Dim capitalcontribution As DataTable = mysql.Query("SELECT contributionDt, typeName, contributionAmount,concat('Contribution-',firstName,' ',middleName,' ',lastName) as 'name' FROM   tblcollectiontype  INNER JOIN  tblmembercontribution     ON (tblcollectiontype.typeId = tblmembercontribution.feeId)  INNER JOIN  tblmember      ON (tblmember.memberId = tblmembercontribution.memberId) where  contributionDt between " + getDate() + " order by contributionDt")
        For i As Integer = 0 To capitalcontribution.Rows.Count - 1
            With table
                .Rows.Add()
                With .Rows(.Rows.Count - 1)
                    Dim dt As Date = capitalcontribution.Rows(i).Item("contributionDt")
                    .Item("date") = dt.ToString("MM/dd/yyyy")
                    .Item("description") = capitalcontribution.Rows(i).Item("typeName")
                    .Item("debit") = 0
                    .Item("credit") = capitalcontribution.Rows(i).Item("contributionAmount")
                    balance += capitalcontribution.Rows(i).Item("contributionAmount")
                    .Item("balance") = balance
                    .Item("details") = capitalcontribution.Rows(i).Item("name")
                    .Item("checkNo") = "-"
                    .Item("VourcherNo") = "-"
                End With
            End With
        Next
        Dim billing As DataTable = mysql.Query("SELECT amountDueDt, billingName,amountPaid, concat(typeName,'-',firstName, ' ', middleName,' ',lastName) as 'name' FROM   tblmember   INNER JOIN cgmea_alps.tblbilling       ON (tblmember.memberId = tblbilling.memberId)  INNER JOIN cgmea_alps.tblcollectiontype      ON (tblcollectiontype.typeId = tblbilling.typeId) where paidFl=1 and amountDueDt between " + getDate() + " order by amountDueDt")
        For i As Integer = 0 To billing.Rows.Count - 1
            With table
                .Rows.Add()
                With .Rows(.Rows.Count - 1)
                    Dim dt As Date = billing.Rows(i).Item("amountDueDt")
                    .Item("date") = dt.ToString("MM/dd/yyyy")
                    .Item("description") = billing.Rows(i).Item("billingName")
                    .Item("debit") = 0
                    .Item("credit") = billing.Rows(i).Item("amountPaid")
                    balance += billing.Rows(i).Item("amountPaid")
                    .Item("balance") = balance
                    .Item("details") = billing.Rows(i).Item("name")
                    .Item("checkNo") = "-"
                    .Item("VourcherNo") = "-"
                End With
            End With
        Next
        Dim dv As New DataView(table)
        dv.Sort = "date"
        balance = 90000000
        table = dv.ToTable
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i).Item("debit") > 0 Then
                balance -= table.Rows(i).Item("debit")
                table.Rows(i).Item("balance") = balance
            ElseIf table.Rows(i).Item("credit") > 0 Then
                balance += table.Rows(i).Item("credit")
                table.Rows(i).Item("balance") = balance
            Else
                table.Rows(i).Item("balance") = balance
            End If
        Next
        Dim rdv As New DataView(table)
        rdv.Sort = "date Desc"

        With cr
            .title = "List of Balance Monitoring and Transaction History Report"
            .addTableField(rdv.ToTable)
            .addParameterField("lblSubHeader", getSubHeader)
            Dim a As String = "Reports\rptBalanceMonitoring.rpt"
            .reportPath(a)
            .launchReport()
        End With

    End Sub

    Private Sub List_of_Official_Receipts_Issued(ByRef cr As PowerNET8.myDocument.Init.CrystalReportViewer)
        Dim xtable As DataTable = getDocumentTable(tableType.officialreceipt)
        Dim mydata As DataTable = mysql.Query("SELECT orNo, orAmount, orDate, concat(firstName,' ',middleName,' ',lastName) as 'payee',paymentRemarks FROM   tblmember  INNER JOIN  tblpayment   ON (tblmember.memberId = tblpayment.memberId) where orNo!='TEMP' and orDate between " + getDate() + " order by orDate desc")
        For i As Integer = 0 To mydata.Rows.Count - 1
            With xtable
                .Rows.Add()
                With .Rows(i)
                    .Item("orNo") = mydata.Rows(i).Item("orNo")
                    .Item("amount") = mydata.Rows(i).Item("orAmount")
                    Dim dt As Date = mydata.Rows(i).Item("orDate")
                    .Item("date") = dt.ToString("yyyy-MM-dd")
                    .Item("payee") = mydata.Rows(i).Item("payee")
                    .Item("voucherNo") = ""
                    .Item("remarks") = mydata.Rows(i).Item("paymentRemarks")
                End With
            End With
        Next

        With cr
            .title = "List of Official Receipts Issued"
            .addTableField(xtable)
            .addParameterField("lblSubHeader", getSubHeader)
            Dim a As String = "Reports\rptOfficialReceiptsIssued.rpt"
            .reportPath(a)
            .launchReport()
        End With
    End Sub

    Private Sub List_of_Checks_Issued(ByRef cr As PowerNET8.myDocument.Init.CrystalReportViewer)
        Dim table As DataTable = getDocumentTable(tableType.checkissued)
        Dim applicationLoan As DataTable = mysql.Query("SELECT checkNo, netProceeds, releasedDt, concat(firstName,' ',middleName,' ',lastName) as 'payee',voucherNo, loanStatus  FROM  tblmember  INNER JOIN  tblloanapplication   ON (tblmember.memberId = tblloanapplication.memberId) where checkNo!='' and releasedDt between " + getDate() + " ")
        Dim x As Integer = 0

        For i As Integer = 0 To applicationLoan.Rows.Count - 1
            With table
                .Rows.Add()
                With .Rows(x)
                    .Item("checkNo") = applicationLoan.Rows(i).Item("checkNo")
                    .Item("amount") = applicationLoan.Rows(i).Item("netProceeds")
                    Dim dt As Date = applicationLoan.Rows(i).Item("releasedDt")
                    .Item("date") = dt.ToString("yyyy-MM-dd")
                    .Item("payee") = applicationLoan.Rows(i).Item("payee")
                    .Item("voucherNo") = applicationLoan.Rows(i).Item("voucherNo")
                    .Item("remarks") = applicationLoan.Rows(i).Item("loanStatus")
                End With
            End With
            x += 1
        Next
        Dim expenses As DataTable = mysql.Query("SELECT checkNo, amount, date_incurred, concat(firstName,' ', middleName,' ',lastName) as 'name', frmEstablishment, voucherNo, remarks FROM   tblmember right JOIN  tbl_expenses    ON (tblmember.memberId = tbl_expenses.frmPerson) where checkNo!='' and date_incurred between " + getDate() + " ")
        For i As Integer = 0 To expenses.Rows.Count - 1
            With table
                .Rows.Add()
                With .Rows(x)
                    .Item("checkNo") = expenses.Rows(i).Item("checkNo")
                    .Item("amount") = expenses.Rows(i).Item("amount")
                    Dim dt As Date = expenses.Rows(i).Item("date_incurred")
                    .Item("date") = dt.ToString("yyyy-MM-dd")

                    If Not IsDBNull(expenses.Rows(i).Item("name")) Then
                        .Item("payee") = expenses.Rows(i).Item("name")
                    Else
                        .Item("payee") = expenses.Rows(i).Item("frmEstablishment")
                    End If

                    .Item("voucherNo") = expenses.Rows(i).Item("voucherNo")
                    .Item("remarks") = expenses.Rows(i).Item("remarks")
                End With
            End With
            x += 1
        Next
        Dim withdrawal As DataTable = mysql.Query("SELECT checkNo, netProceeds AS amount, withdrawDt, concat(firstName,' ', middleName,' ',lastName) as 'name', voucherNo, withdrawalRemarks FROM   tblmember  right JOIN  tblmemberwithdrawal    ON (tblmember.memberId = tblmemberwithdrawal.memberId) where checkNo!='' and withdrawDt between " + getDate() + " ")
        For i As Integer = 0 To withdrawal.Rows.Count - 1
            With table
                .Rows.Add()
                With .Rows(x)
                    .Item("checkNo") = withdrawal.Rows(i).Item("checkNo")
                    .Item("amount") = withdrawal.Rows(i).Item("amount")
                    Dim dt As Date = withdrawal.Rows(i).Item("withdrawDt")
                    .Item("date") = dt.ToString("yyyy-MM-dd")
                    .Item("payee") = withdrawal.Rows(i).Item("name")
                    .Item("voucherNo") = withdrawal.Rows(i).Item("voucherNo")
                    .Item("remarks") = withdrawal.Rows(i).Item("withdrawalRemarks")
                End With
            End With
            x += 1
        Next
        With cr
            .title = "List of Checks Issued "
            .addTableField(table)
            .addParameterField("lblSubHeader", getSubHeader)
            Dim a As String = "Reports\rptCheckIssued.rpt"
            'Dim a As String = gApplicationPath + "\Reports\rptCheckIssued.rpt"
            .reportPath(a)
            .launchReport()
        End With

    End Sub

    Private Function getCollectionBilling(ByVal type As String)
        Dim mydata As DataTable = mysql.Query("SELECT sum(amountPaid) as 'total' FROM   tblcollectiontype  INNER JOIN  tblbilling     ON (tblcollectiontype.typeId = tblbilling.typeId) where typeName = '" + type + "' and paidFl=1 and cancelFl=0 and amountDueDt between " + getDate())
        If mydata.Rows.Count > 0 Then
            Return mydata.Rows(0).Item(0)
        End If
    End Function

End Class