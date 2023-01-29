<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="Top_High_Schools.index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Top-High School Management System</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="" name="keywords">
    <meta content="" name="description">

    <!-- Favicons -->
    <link href="img/favicon.png" rel="icon">
    <link href="img/apple-touch-icon.png" rel="apple-touch-icon">

    <!-- Google Fonts -->
    <link href="css/css.css" rel="stylesheet" />

    <!-- Bootstrap CSS File -->
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Libraries CSS Files -->
    <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="lib/animate/animate.min.css" rel="stylesheet">
    <link href="lib/ionicons/css/ionicons.min.css" rel="stylesheet">
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="lib/lightbox/css/lightbox.min.css" rel="stylesheet">

    <!-- Main Stylesheet File -->
    <link href="css/style.css" rel="stylesheet">
</head>

<body>

    <!--==========================
    Header
  ============================-->
    <header id="header">
        <div class="container-fluid">

            <div id="logo" class="pull-left">
                <h4><a href="#intro" class="scrollto"><asp:Label ID="lblcompname" runat="server" Text="" ForeColor="White"></asp:Label></a></h4>
                <!-- Uncomment below if you prefer to use an image logo -->
                <!--  <a href="#intro"><img src="img/logo.png" alt="" title="" /></a>!-->
            </div>

            <nav id="nav-menu-container">
                <ul class="nav-menu">
                    <li class="menu-active"><a href="#intro">Home</a></li>
                    <li><a href="#about">About Us</a></li>
                    <li><a href="#admission">Admission</a></li>
                    <li><a href="#academics">Academics</a></li>
                    <li><a href="#gallery">Gallery</a></li>
                    <li><a href="#contact">Contact</a></li>
                    <li><a href="Login.aspx">Login</a>
                        <ul>
                            <li><a href="Login.aspx">Teacher's & Admin</a></li>
                            <li><a href="Log_in_Portal.aspx">Portal</a></li>
                        </ul>
                    </li>

                </ul>
            </nav>
            <!-- #nav-menu-container -->
        </div>
    </header>
    <!-- #header -->

    <!--==========================
    Intro Section
  ============================-->
    <section id="intro">
        <div class="intro-container">
            <div id="introCarousel" class="carousel  slide carousel-fade" data-ride="carousel">

                <ol class="carousel-indicators"></ol>

                <div class="carousel-inner" role="listbox">

                    <div class="carousel-item active">
                        <div class="carousel-background">
                            <img src="img/school/Classroom-Activities-21.jpg" alt="">
                        </div>
                        <div class="carousel-container">
                            <div class="carousel-content">
                                <h2>Welcome Message</h2>
                                <p>
                                    (Tell about your school)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in.
                                </p>
                                <a href="Login.aspx" class="btn-get-started scrollto">Login</a>
                                <a href="Log_in_Portal.aspx" class="btn-get-started scrollto">Portal</a>
                            </div>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <div class="carousel-background">
                            <img src="img/school/Elementary-after-school-activities-fall-garnet-valley-2019.jpg" alt="">
                        </div>
                        <div class="carousel-container">
                            <div class="carousel-content">
                                <h2>Welcome Message</h2>
                                <p>
                                    (Tell about your school)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in.
                                </p>
                                <a href="Login.aspx" class="btn-get-started scrollto">Login</a>
                                <a href="Log_in_Portal.aspx" class="btn-get-started scrollto">Portal</a>
                            </div>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <div class="carousel-background">
                            <img src="img/school/488773.jpg" alt="">
                        </div>
                        <div class="carousel-container">
                            <div class="carousel-content">
                                <h2>Welcome Message</h2>
                                <p>
                                    (Tell about your school)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in.
                                </p>
                                <a href="Login.aspx" class="btn-get-started scrollto">Login</a>
                                <a href="Log_in_Portal.aspx" class="btn-get-started scrollto">Portal</a>
                            </div>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <div class="carousel-background">
                            <img src="img/school/IMG_7623.jpg" alt="">
                        </div>
                        <div class="carousel-container">
                            <div class="carousel-content">
                                <h2>Welcome Message</h2>
                                <p>
                                    (Tell about your school)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in.
                                </p>
                                <a href="Login.aspx" class="btn-get-started scrollto">Login</a>
                                <a href="Log_in_Portal.aspx" class="btn-get-started scrollto">Portal</a>
                            </div>
                        </div>
                    </div>
                </div>

                <a class="carousel-control-prev" href="#introCarousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon ion-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>

                <a class="carousel-control-next" href="#introCarousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon ion-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>

            </div>
        </div>
    </section>
    <!-- #intro -->

    <main id="main">

        <!--==========================
      Featured Services Section
    ============================-->
        <section id="featured-services">
            <div class="container">
                <div class="row">

                    <div class="col-lg-4 box book-box">
                        <i class="ion-ios-bookmarks-outline"></i>
                        <h4 class="title"><a href="">Up-to-Date</a></h4>
                        <p class="description">We keep our learners up to date in the world of academics.</p>
                    </div>

                    <div class="col-lg-4 box box-bg">
                        <i class="ion-ios-stopwatch-outline"></i>
                        <h4 class="title"><a href="">Parent's Satisfaction</a></h4>
                        <p class="description">Helping learner's to reach their academic goal's is our topmost priority.</p>
                    </div>

                    <div class="col-lg-4 box box-heart">
                        <i class="ion-ios-heart-outline"></i>
                        <h4 class="title"><a href="">Our Relationship with Learner's & Parent's</a></h4>
                        <p class="description">We ensure our Learner's & Parent's enjoy a warm and welcoming environment.</p>
                    </div>

                </div>
            </div>
        </section>
        <!-- #featured-services -->

        <!--==========================
      About Us Section
    ============================-->
        <section id="about">
            <div class="container">

                <header class="section-header">
                    <h3>About Us</h3>
                    <p>
                        (Tell about your school)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in. 
.
                    </p>
                </header>

                <div class="row about-cols">

                    <div class="col-md-4 wow fadeInUp">
                        <div class="about-col">
                            <div class="img">
                                <img src="img/school/1572.jpg" alt="" class="img-fluid">
                                <div class="icon"><i class="ion-ios-speedometer-outline"></i></div>
                            </div>
                            <h2 class="title"><a href="#">Our Mission</a></h2>
                            <p>
                                Mission Message
                            </p>
                        </div>
                    </div>

                    <div class="col-md-4 wow fadeInUp" data-wow-delay="0.1s">
                        <div class="about-col">
                            <div class="img">
                                <img src="img/school/f_WXZrf7.png" alt="" class="img-fluid">
                                <div class="icon"><i class="ion-ios-list-outline"></i></div>
                            </div>
                            <h2 class="title"><a href="#">Our Plan</a></h2>
                            <p>
                                What are your plans,objectives and aims.
                            </p>
                        </div>
                    </div>

                    <div class="col-md-4 wow fadeInUp" data-wow-delay="0.2s">
                        <div class="about-col">
                            <div class="img">
                                <img src="img/school/images.jpg" alt="" class="img-fluid">
                                <div class="icon"><i class="ion-ios-eye-outline"></i></div>
                            </div>
                            <h2 class="title"><a href="#">Our Vision</a></h2>
                            <p>
                                Talk about your vission here
                            </p>
                        </div>
                    </div>

                </div>

            </div>
        </section>
        <!-- #about -->

        <!--==========================
      Services Section
    ============================-->
        <section id="admission">
            <div class="container">

                <header class="section-header wow fadeInUp">
                    <h3>Admission</h3>
                    <p>We offer fast, reliable and up-to-date academic knowledge which include:</p>
                </header>

                <div class="row">

                    <div class="col-md-6 box wow bounceInUp" data-wow-duration="1.4s">
                        <h4 class="title"><a href=""></a>Fees</h4>
                        <p class="description">
                            (Talk about admission fee process)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in..
                        </p>
                    </div>

                    <div class="col-md-6 box wow bounceInUp" data-wow-duration="1.4s">
                        <h4 class="title"><a href=""></a>Enrollment</h4>
                        <p class="description">
                            (Talk about enrollment process)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in..
                        </p>
                    </div>
                </div>

            </div>
        </section>
        <!-- #services -->

        <!--==========================
      Services Section
    ============================-->
        <section id="academics">
            <div class="container">

                <header class="section-header wow fadeInUp">
                    <h3>Academics</h3>
                    <p>We offer fast, reliable and up-to-date academic knowledge which include:</p>
                </header>

                <div class="row">

                    <div class="col-md-6 box wow bounceInUp" data-wow-duration="1.4s">
                        <h4 class="title"><a href="">Curriculum</a></h4>
                        <p class="description">
                            (Talk about curriculum info)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in..
                        </p>
                    </div>

                    <div class="col-md-6 box wow bounceInUp" data-wow-duration="1.4s">
                        <h4 class="title"><a href="">Departments</a></h4>
                        <p class="description">
                            (Talk about department info)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in..
                        </p>
                    </div>

                </div>

            </div>
        </section>
        <!-- #services -->


        <!--==========================
      Portfolio Section
    ============================-->
        <section id="gallery" class="section-bg">
            <div class="container">

                <header class="section-header">
                    <h3 class="section-title">Our Gallery</h3>
                </header>

                <div class="row">
                    <div class="col-lg-12">
                        <ul id="portfolio-flters">
                            <li data-filter="*" class="filter-active">All</li>
                            <li data-filter=".filter-app">Classes Time</li>
                            <li data-filter=".filter-card">Sports</li>
                            <li data-filter=".filter-web">Other Activities</li>
                        </ul>
                    </div>
                </div>

                <div class="row portfolio-container">

                    <div class="col-lg-4 col-md-6 portfolio-item filter-app wow fadeInUp">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/back-to-school-activities-backgroud.jpg" class="img-fluid" alt="">
                                <a href="img/school/back-to-school-activities-backgroud.jpg" data-lightbox="portfolio" data-title="App 1" class="link-preview" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%-- <h4><a href="#">App 1</a></h4>
                                <p>Windows Phone App</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-web wow fadeInUp" data-wow-delay="0.1s">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/nsukka_newheader_1575908515.jpg" class="img-fluid" alt="">
                                <a href="img/school/nsukka_newheader_1575908515.jpg" class="link-preview" data-lightbox="portfolio" data-title="Web 3" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%-- <h4><a href="#">Offline & Online</a></h4>
                                <p>Database</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-app wow fadeInUp" data-wow-delay="0.2s">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/Elementary_classroom_in_Alaska.jpg" class="img-fluid" alt="">
                                <a href="img/school/Elementary_classroom_in_Alaska.jpg" class="link-preview" data-lightbox="portfolio" data-title="App 2" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%-- <h4><a href="#">App 2</a></h4>
                                <p>Apple Phone And Tablet App</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-card wow fadeInUp">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/activities-for-school-kids-2narrow.jpg" class="img-fluid" alt="">
                                <a href="img/school/activities-for-school-kids-2narrow.jpg" class="link-preview" data-lightbox="portfolio" data-title="Card 2" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%--<h4><a href="#">Card 2</a></h4>
                                <p>Card</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-web wow fadeInUp" data-wow-delay="0.1s">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/IMG_7623.jpg" class="img-fluid" alt="">
                                <a href="img/school/IMG_7623.jpg" class="link-preview" data-lightbox="portfolio" data-title="Web 2" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%--<h4><a href="#">Web 2</a></h4>--%>
                                <%--   <p>Website</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-app wow fadeInUp" data-wow-delay="0.2s">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/Touch-Africa-Walmer-Primary-School-Inside.jpg" class="img-fluid" alt="">
                                <a href="img/school/Touch-Africa-Walmer-Primary-School-Inside.jpg" class="link-preview" data-lightbox="portfolio" data-title="App 3" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%--<h4><a href="#">App 3</a></h4>
                                <p>Android Phone and Tablet App</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-card wow fadeInUp">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/1571394692location116.jpg" class="img-fluid" alt="">
                                <a href="img/school/1571394692location116.jpg" class="link-preview" data-lightbox="portfolio" data-title="Card 1" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%--<h4><a href="#">Card 1</a></h4>
                                <p>Card</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-card wow fadeInUp" data-wow-delay="0.1s">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/computer-lab-700x400.jpg" class="img-fluid" alt="">
                                <a href="img/school/computer-lab-700x400.jpg" class="link-preview" data-lightbox="portfolio" data-title="Card 3" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%--<h4><a href="#">Card 3</a></h4>
                                <p>Card</p>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 portfolio-item filter-web wow fadeInUp" data-wow-delay="0.2s">
                        <div class="portfolio-wrap">
                            <figure>
                                <img src="img/school/1572.jpg" class="img-fluid" alt="">
                                <a href="img/school/1572.jpg" class="link-preview" data-lightbox="portfolio" data-title="Web 1" title="Preview"><i class="ion ion-eye"></i></a>
                                <a href="#" class="link-details" title="More Details"><i class="ion ion-android-open"></i></a>
                            </figure>

                            <div class="portfolio-info">
                                <%--   <h4><a href="#">Web 1</a></h4>
                                <p>Web</p>--%>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </section>
        <!-- #portfolio -->



        <!--==========================
      Contact Section
    ============================-->
        <section id="contact" class="section-bg wow fadeInUp">
            <div class="container">

                <div class="section-header">
                    <h3>Contact Us</h3>
                    <p>For more info please use any fo our contacts below to reach us.</p>
                </div>

                <div class="row contact-info">

                    <div class="col-md-4">
                        <div class="contact-address">
                            <i class="ion-ios-location-outline"></i>
                            <h3>Address</h3>
                            <address>P.O.Box UP 000, KS - AC, Our World</address>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="contact-phone">
                            <i class="ion-ios-telephone-outline"></i>
                            <h3>Phone Number</h3>
                            <p><a href="tel:+233594589329">+233 (0) 00 000 0000</a></p>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="contact-email">
                            <i class="ion-ios-email-outline"></i>
                            <h3>Email</h3>
                            <p><a href="mailto:info@tophighitsolutions.com">info@tophighitsolutions.com</a></p>
                        </div>
                    </div>

                </div>

                <div class="form">
                    <div id="sendmessage">Your message has been sent. Thank you!</div>
                    <div id="errormessage"></div>
                    <form action="" method="post" role="form" class="contactForm">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <input type="text" name="name" class="form-control" id="name" placeholder="Your Name" data-rule="minlen:4" data-msg="Please enter at least 4 chars" />
                                <div class="validation"></div>
                            </div>
                            <div class="form-group col-md-6">
                                <input type="email" class="form-control" name="email" id="email" placeholder="Your Email" data-rule="email" data-msg="Please enter a valid email" />
                                <div class="validation"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name="subject" id="subject" placeholder="Subject" data-rule="minlen:4" data-msg="Please enter at least 8 chars of subject" />
                            <div class="validation"></div>
                        </div>
                        <div class="form-group">
                            <textarea class="form-control" name="message" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="Message"></textarea>
                            <div class="validation"></div>
                        </div>
                        <div class="text-center">
                            <button type="submit">Send Message</button>
                        </div>
                    </form>
                </div>

            </div>
        </section>
        <!-- #contact -->

    </main>

    <!--==========================
    Footer
  ============================-->
    <footer id="footer">
        <div class="footer-top">
            <div class="container">
                <div class="row">

                    <div class="col-lg-3 col-md-6 footer-info">
                        <h3>School</h3>
                        <p>(Tell about your school)... Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in.</p>
                        <p></p>
                    </div>

                    <div class="col-lg-3 col-md-6 footer-links">
                        <h4>Useful Links</h4>
                        <ul>
                            <li><i class="ion-ios-arrow-right"></i><a href="#">Home</a></li>
                            <li><i class="ion-ios-arrow-right"></i><a href="#">About us</a></li>
                            <li><i class="ion-ios-arrow-right"></i><a href="#">Admission & Academics</a></li>
                            <li><i class="ion-ios-arrow-right"></i><a href="#">Terms of service</a></li>
                            <li><i class="ion-ios-arrow-right"></i><a href="#">Privacy policy</a></li>
                        </ul>
                    </div>

                    <div class="col-lg-3 col-md-6 footer-contact">
                        <h4>Contact Us</h4>
                        <p>
                            P.O.Box UP 000, KS,
                            <br>
                            AC , AS ,<br>
                            Our World
                            <br>
                            <strong>Phone Line-1:</strong> +233 (0)00 000 0000<br>
                            <strong>Phone Line-2:</strong> +233 (0)00 000 0000<br>
                            <strong>Phone Line-2:</strong> +233 (0)00 000 0000<br>
                            <strong>Email:</strong> info@tophighitsolutions.com<br>
                        </p>

                        <div class="social-links">
                            <a href="#" class="twitter"><i class="fa fa-twitter"></i></a>
                            <a href="#" class="facebook"><i class="fa fa-facebook"></i></a>
                            <a href="#" class="instagram"><i class="fa fa-instagram"></i></a>
                            <a href="#" class="google-plus"><i class="fa fa-google-plus"></i></a>
                            <a href="#" class="linkedin"><i class="fa fa-linkedin"></i></a>
                        </div>

                    </div>

                    <div class="col-lg-3 col-md-6 footer-newsletter">
                        <h4>Our Newsletter</h4>
                        <p>Subscribe to our newsletter list to receive our latest offers & news.</p>
                        <form action="" method="post">
                            <input type="email" name="email"><input type="submit" value="Subscribe">
                        </form>
                    </div>

                </div>
            </div>
        </div>

        <div class="container">
            <div class="copyright">
                &copy; Copyright <strong>TopHigh I.T Solutions</strong>. All Rights Reserved
            </div>
            <div class="credits">
                <!--
         
        -->
                Designed by <a href="http://tophighitsolutions.com/">TopHigh</a>
            </div>
        </div>



    </footer>
    <!-- #footer -->

    <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>
    <!-- Uncomment below i you want to use a preloader -->
    <!-- <div id="preloader"></div> -->

    <!-- JavaScript Libraries -->
    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/jquery/jquery-migrate.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="lib/easing/easing.min.js"></script>
    <script src="lib/superfish/hoverIntent.js"></script>
    <script src="lib/superfish/superfish.min.js"></script>
    <script src="lib/wow/wow.min.js"></script>
    <script src="lib/waypoints/waypoints.min.js"></script>
    <script src="lib/counterup/counterup.min.js"></script>
    <script src="lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="lib/isotope/isotope.pkgd.min.js"></script>
    <script src="lib/lightbox/js/lightbox.min.js"></script>
    <script src="lib/touchSwipe/jquery.touchSwipe.min.js"></script>
    <!-- Contact Form JavaScript File -->
    <script src="contactform/contactform.js"></script>

    <!-- Template Main Javascript File -->
    <script src="js/main.js"></script>

</body>
</html>
