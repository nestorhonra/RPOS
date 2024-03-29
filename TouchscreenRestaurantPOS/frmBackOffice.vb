﻿Public Class frmBackOffice

    Private Sub frmBackOffice_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnDBBackup.Visible = False
        btnDBSetup.Visible = False
        btnDBRestore.Visible = False
        btnCurrency.Visible = False
        btnPurchase.Visible = False
        btnExpense.Visible = False
        btnExpenseType.Visible = False
        btnVoucher.Visible = False
        btnDelivery.Visible = False
        btnRecipe.Visible = False
        btnAbout.Visible = False
        btnStore.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        With frmOption
            .lblUserType.Text = Me.lblUserType.Text
            .lblUser.Text = Me.lblUser.Text
            .Show()
        End With
        Me.Close()
    End Sub

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        With frmRestaurantMaster
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnCurrency_Click(sender As Object, e As EventArgs) Handles btnCurrency.Click
        With frmCurrency
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        With frmCategory
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnKitchen_Click(sender As Object, e As EventArgs) Handles btnKitchen.Click
        With frmKitchen_Section
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        With frmItem
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnItemStock_Click(sender As Object, e As EventArgs) Handles btnItemStock.Click
        With frmStock_Store
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnTables_Click(sender As Object, e As EventArgs) Handles btnTables.Click
        With frmTable
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnNotes_Click(sender As Object, e As EventArgs) Handles btnNotes.Click
        With frmNotesMaster
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnPrinterSetup_Click(sender As Object, e As EventArgs) Handles btnPrinterSetup.Click
        With frmPrinterSetting
            .ShowDialog()
        End With
    End Sub

    Private Sub btnDBSetup_Click(sender As Object, e As EventArgs) Handles btnDBSetup.Click
        With frmSqlServerSetting
            .ShowDialog()
        End With
    End Sub

    Private Sub btnDBBackup_Click(sender As Object, e As EventArgs) Handles btnDBBackup.Click

    End Sub

    Private Sub btnDBRestore_Click(sender As Object, e As EventArgs) Handles btnDBRestore.Click

    End Sub

    Private Sub btnOthers_Click(sender As Object, e As EventArgs) Handles btnOthers.Click
        With frmOthersSetting
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnWHType_Click(sender As Object, e As EventArgs) Handles btnWHType.Click
        With frmWarehouseType
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnWH_Click(sender As Object, e As EventArgs) Handles btnWH.Click
        With frmWarehouse
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click
        With frmProduct
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        With frmSupplier
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        With frmPurchase
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        With frmPayment
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnStore_Click(sender As Object, e As EventArgs) Handles btnStore.Click

    End Sub

    Private Sub btnSTF_Click(sender As Object, e As EventArgs) Handles btnSTF.Click
        With frmStockTransfer
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnExpenseType_Click(sender As Object, e As EventArgs) Handles btnExpenseType.Click
        With frmExpenseType
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnExpense_Click(sender As Object, e As EventArgs) Handles btnExpense.Click
        With frmExpense
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnVoucher_Click(sender As Object, e As EventArgs) Handles btnVoucher.Click
        With frmVoucher
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        With frmDeliveryPersonRecord
            '.lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnRecipe_Click(sender As Object, e As EventArgs) Handles btnRecipe.Click
        With frmRecipe
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnWorkPeriod_Click(sender As Object, e As EventArgs) Handles btnWorkPeriod.Click
        With frmWorkPeriodReport
            .ShowDialog()
        End With
    End Sub

    Private Sub btnPOSRep_Click(sender As Object, e As EventArgs) Handles btnPOSRep.Click
        With frmRestaurantPOSReport
            .ShowDialog()
        End With
    End Sub

    Private Sub btnAcctgRep_Click(sender As Object, e As EventArgs) Handles btnAcctgRep.Click
        With frmAccountingReport
            .ShowDialog()
        End With
    End Sub

    Private Sub btnRegistration_Click(sender As Object, e As EventArgs) Handles btnRegistration.Click
        With frmRegistration
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        With frmLogs
            .ShowDialog()
        End With
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        With frmAbout
            .ShowDialog()
        End With
    End Sub

    Private Sub btnWallets_Click(sender As Object, e As EventArgs) Handles btnWallets.Click
        With frmWallet
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnRefund_Click(sender As Object, e As EventArgs) Handles btnRefund.Click
        With frmRefund
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        With frmCustomerRegistration
            .lblUser.Text = Me.lblUser.Text
            .ShowDialog()
        End With
    End Sub
End Class