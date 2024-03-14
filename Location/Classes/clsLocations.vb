Imports System.Windows.Forms

Public Class Locations

#Region "Class Locations Declarations"

    Public Sub New(ByVal fn As String, ByVal path As String, ByVal userId As Integer, ByVal roleId As Integer, ByVal gProduct As String)
        gConnStringFileName = fn
        gApplicationPath = path
        gUserID = userId
        gRoleID = roleId
        gAssemblyProduct = gProduct
        ImageDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\images"
        PresetDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\presets"
    End Sub

#End Region

#Region "Class Locations Class Declarations"

    Public Function NewclsBarangay()
        Try
            NewclsBarangay = New Barangay.Barangay
            Return NewclsBarangay
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsCountry()
        Try
            NewclsCountry = New Country.Country
            Return NewclsCountry
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsDistrict()
        Try
            NewclsDistrict = New District.District
            Return NewclsDistrict
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMunicipality()
        Try
            NewclsMunicipality = New Municipality.Municipality
            Return NewclsMunicipality
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsProvince()
        Try
            NewclsProvince = New Province.Province
            Return NewclsProvince
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsRegion()
        Try
            NewclsRegion = New Region.Region
            Return NewclsRegion
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsZipCode()
        Try
            NewclsZipCode = New ZipCode.ZipCode
            Return NewclsZipCode
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class Locations Forms Declarations"

    Public Function NewfrmBarangay() As Form
        Try
            NewfrmBarangay = New frmBarangay
            Return NewfrmBarangay
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmBarangayFinder() As Form
        Try
            NewfrmBarangayFinder = New frmBarangayFinder
            Return NewfrmBarangayFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmDistrict() As Form
        Try
            NewfrmDistrict = New frmDistrict
            Return NewfrmDistrict
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmDistrictFinder() As Form
        Try
            NewfrmDistrictFinder = New frmDistrictFinder
            Return NewfrmDistrictFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMunicipality() As Form
        Try
            NewfrmMunicipality = New frmMunicipality
            Return NewfrmMunicipality
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMunicipalityFinder() As Form
        Try
            NewfrmMunicipalityFinder = New frmMunicipalityFinder
            Return NewfrmMunicipalityFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmProvince() As Form
        Try
            NewfrmProvince = New frmProvince
            Return NewfrmProvince
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmProvinceFinder() As Form
        Try
            NewfrmProvinceFinder = New frmProvinceFinder
            Return NewfrmProvinceFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmRegion() As Form
        Try
            NewfrmRegion = New frmRegion
            Return NewfrmRegion
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmRegionFinder() As Form
        Try
            NewfrmRegionFinder = New frmRegionFinder
            Return NewfrmRegionFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmZipCode() As Form
        Try
            NewfrmZipCode = New frmZipCode
            Return NewfrmZipCode
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmZipCodeFinder() As Form
        Try
            NewfrmZipCodeFinder = New frmZipCodeFinder
            Return NewfrmZipCodeFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCountry() As Form
        Try
            NewfrmCountry = New frmCountry
            Return NewfrmCountry
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCountryFinder() As Form
        Try
            NewfrmCountryFinder = New frmCountryFinder
            Return NewfrmCountryFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Class
