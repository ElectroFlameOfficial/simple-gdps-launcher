<?php
error_reporting(0);
include "../incl/lib/connection.php";
require "../incl/lib/mainLib.php";
$gs = new mainLib();
if(!empty($_POST["url"])){
 	$songID = $gs->songReupload($_POST["url"]);
    $string["songAddError-2"] = "Invalid link";
    $string["songAddError-3"] = "This track has already been added";
    $string["songAddError-4"] = "Unable to add track. Maybe this track is copyright protected";
                        	if($songID < 0){
                        		$errorDesc = $string["songAddError$songID"];
                        		echo "Error: $songID ($errorDesc)";
                        	}else{
                        		echo "Track added: $songID";
                        	}
                        }else{
							exit("-1");
						}
?>