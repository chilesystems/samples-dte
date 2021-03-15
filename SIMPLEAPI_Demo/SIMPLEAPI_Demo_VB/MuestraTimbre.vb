Imports System.IO
Imports System.Text

Public Class MuestraTimbre
    Private Sub MuestraTimbre_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub botonCargarDTE_Click(sender As Object, e As EventArgs) Handles botonCargarDTE.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim outMessage As String = ""
        openFileDialog1.ShowDialog()
        Dim pathFile As String = openFileDialog1.FileName
        Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))


        '//var envioBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString<ChileSystems.DTE.Engine.Envio.EnvioBoleta>(xml);
        '    //pictureBoxTimbre.Image = envioBoleta.SetDTE.DTEs[0].Documento.TimbrePDF417(out outMessage);


        Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
        pictureBoxTimbre.BackgroundImage = dte.Documento.TimbrePDF417(outMessage)

        '//dte.Exportaciones.TimbrePDF417(out outMessage);

    End Sub

    Private Sub botonValidar_Click(sender As Object, e As EventArgs) Handles botonValidar.Click
        Dim openFileDialog1 As New OpenFileDialog
        Dim outMessage As String = ""

        '//openFileDialog1.Title = "Seleccione XML de timbre";
        '    //openFileDialog1.ShowDialog();
        '    //string pathFile = openFileDialog1.FileName;
        '    //string xmlTimbreAux = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
        '    //var dteAux = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xmlTimbreAux);
        '    //string xmlTimbre = dteAux.Documento.TED.DatosBasicos.ToString();
        '    //string xmlTimbre = File.ReadAllText("C:\\Users\\Gonzalo\\Desktop\\sisfredo\\TmpTimbreCert_89.xml", Encoding.GetEncoding("ISO-8859-1"));


        openFileDialog1.Title = "Seleccione XML de CAF"
        openFileDialog1.ShowDialog()
        Dim pathFilecaf = openFileDialog1.FileName
        Dim xmlCaf = File.ReadAllText(pathFilecaf, Encoding.GetEncoding("ISO-8859-1"))

        openFileDialog1.Title = "Seleccione XML de EnvioBoleta"
        openFileDialog1.ShowDialog()
        Dim pathFileEnvioBoleta = openFileDialog1.FileName
        Dim xmlEnvioBoleta = File.ReadAllText(pathFileEnvioBoleta, Encoding.GetEncoding("ISO-8859-1"))
        Dim envioBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString(Of ChileSystems.DTE.Engine.Envio.EnvioBoleta)(xmlEnvioBoleta)
        Dim firmalDD = envioBoleta.SetDTE.DTEs(0).Documento.TED.FirmaDigital.Firma

        Dim privateKey = ChileSystems.DTE.Engine.CAFHandler.CAFHandler.GetPrivateKey(pathFilecaf)
        Dim firmaResultante = SIMPLE_API.Security.Timbre.Timbre.Timbrar(envioBoleta.SetDTE.DTEs(0).Documento.TED.DatosBasicos.ToString(), privateKey)

        MessageBox.Show((firmaResultante = firmalDD).ToString())
    End Sub
End Class