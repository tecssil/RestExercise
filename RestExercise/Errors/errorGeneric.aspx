<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorGeneric.aspx.cs" Inherits="RestExercise.Errors.errorGeneric" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Error</title>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

</head>
<body>
<br />
    <div class="wrapper">
        <div class="row">
        </div>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <form id="Form1" role="form" runat="server">
                    <div class="row">
                        <div class="col-md-4 col-md-offset-4">
                            <div class="login-panel panel panel-default">  
                                <div class="panel-heading">
                                    <h3 class="panel-title">System Error</h3>
                                </div>
                                <div class="panel-body">
                                <center>
                    	            <p >
							            <strong>Error</strong>
			                            <br />
							            <br />
                                        We have internal problems with our system. Please get in touch with our support.
                                        <br />
                                        <br />
                                        <strong>THANKS</strong>
                                    </p>									     
                                </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>    
        </div>
    </div>
</body>
</html>
