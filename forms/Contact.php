<? php

$name = $_POST["name"];
$email = $_POST["email"];
$subject = $_POST["subject"];
$message = $_POST["message"];

require "vendor/autoload.php";

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;

$mail = new PHPMailer(true);

$mail->isSMTP();
$mail->SMTPAuth = true;

$mail ->Host = "smtp.example.com"
$mail ->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;
$mail ->Port = 587;
 
$mail ->Username= "vdgopsrinivasan@gmail.com";
$mail ->Password = "Devops@23";

$mail ->setFrom($mail, $name);
$mail ->addAddress("vdgopsrinivasan@gmail.com", "Dave");

$mail ->Subject = $subject;
$mail ->Body = $message;

$mail ->send();

echo "emai sent";

?>