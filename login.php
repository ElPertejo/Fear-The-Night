<?php
    $servername = "localhost";
    $username = "";
    $password = "";
    $dbName ="game_proj";
    //Conexion
    $conn = new mysqli ($servername, $username, $password, $dbName);
    //Comprobacion
    if(!$conn) {
         die("Connection failed.". mysqli_connect_error());
    }
    else echo("Connection Success");
    
   
?>