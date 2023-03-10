"use strict";

function isMobileDeviceUsed() {
    var e = !1;
    return (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) && (e = !0), e
}

function sliderInit() {
    $(".gal-slider").slick({
        autoplay: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        arrows: true,
        dots: !0,
        responsive: [{
            breakpoint: 1200,
            settings: {
                slidesToShow: 2
            }
        }, {
            breakpoint: 600,
            settings: {
                slidesToShow: 1
            }
        }]
    }),
    $("#classes-slider").slick({
        autoplay: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        arrows: true,
        dots: !0,
        responsive: [{
            breakpoint: 1200,
            settings: {
                slidesToShow: 2
            }
        }, {
            breakpoint: 600,
            settings: {
                slidesToShow: 1
            }
        }]
    }), $("#event-slider").slick({
        autoplay: true,
        slidesToShow: 2,
        slidesToScroll: 1,
        infinite: !1,
        arrows: true,
        dots: !0,
        responsive: [{
            breakpoint: 1200,
            settings: {
                slidesToShow: 1
            }
        }]
    }), $("#testimonial-slider").slick({
        autoplay: true,
        slidesToShow: 2,
        slidesToScroll: 1,
        infinite: !1,
        arrows: true,
        dots: !0,
        responsive: [{
            breakpoint: 768,
            settings: {
                slidesToShow: 1
            }
        }]
    }), $("#team-slider").slick({
        autoplay: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        arrows: true,
        dots: !0,
        responsive: [{
            breakpoint: 1200,
            settings: {
                slidesToShow: 2
            }
        }, {
            breakpoint: 768,
            settings: {
                slidesToShow: 1
            }
        }]
    }), $("#home-slider").on("init", function(e, a) {
        $("#home-slider .slick-active .inner-home-slider").addClass("animate-slide")
    }), $("#home-slider").slick({
        autoplay: true,
        dots: !0,
        prevArrow: ".home-slider-wrap .slider-arrow.arrow-left",
        nextArrow: ".home-slider-wrap .slider-arrow.arrow-right",
        responsive: [{
            breakpoint: 700,
            settings: {
                arrows: !1
            }
        }]
    }), $("#home-slider").on("afterChange", function(e, a, t) {
        $("#home-slider .slick-slide .inner-home-slider").removeClass("animate-slide"), $("#home-slider .slick-active .inner-home-slider").addClass("animate-slide")
    }), $("#second-testimonial").slick({
        autoplay: true,
        infinite: !1,
        dots: !0,
        arrows: true,
    }), $("#blog-slider-1").slick({})
}


function mobileNav() {
    $(".wrap-to-show i").on("click", function() {
        var e = $(this).closest(".wrap-to-show");
        e.next("ul").is(":visible") ? (e.next("ul").slideUp(), e.removeClass("show-mob-nav")) : (e.next("ul").slideToggle(), e.addClass("show-mob-nav"))
    }), $(".humburger").on("click", function() {
        $(".header-nav").addClass("show-header-nav"), $(".fade-bg").addClass("fade-true"), $("html").css({
            overflow: "hidden"
        })
    }), $(".close-menu").on("click", function() {
        $(".header-nav").removeClass("show-header-nav"), $(".fade-bg").removeClass("fade-true"), $("html").css({
            overflow: "visible"
        })
    }), $(".fade-bg").on("click", function() {
        $(".header-nav").removeClass("show-header-nav"), $(".fade-bg").removeClass("fade-true"), $("html").css({
            overflow: "visible"
        })
    })
}

function mobileSearch() {
    $(".show-search").on("click", function() {
        $(".search-overlay-wrap").addClass("show-search-overlay"), $(".search-overlay input").focus(), $("html").css({
            overflow: "hidden"
        })
    }), $(".close-search-overlay").on("click", function() {
        $(".search-overlay-wrap").removeClass("show-search-overlay"), $(".search-overlay").trigger("reset"), $("html").css({
            overflow: "visible"
        })
    })
}

function animateScroll() {
    var e = $("*").attr("data-animation-section");
    void 0 !== e && !1 !== e && $(window).on("scroll", function() {
        var e = $(window).scrollTop();
        $("*[data-animation-section]").each(function() {
            var a = $(this).offset().top,
                t = ($(this).outerHeight(!1), $(window).height()),
                o = $(this).find("*[data-animation-block]").attr("data-animation-block");
            e > a - .8 * t && $(this).find("*[data-animation-block]").addClass(o)
        })
    })
}

function progressAnimation() {
    $("*").hasClass("progress-wrap") && $(window).on("scroll", function() {
        var e = $(window).scrollTop(),
            a = $(window).height();
        $(".progress-wrap").each(function() {
            var t = $(this).offset().top;
            if (e > t - .8 * a) {
                var o = $(this).find(".progress-line"),
                    i = o.attr("data-value");
                o.css({
                    width: i + "%"
                })
            }
        })
    })
}

function makeTimer() {
    var e = new Date("december 30, 2018 12:00:00 PDT"),
        e = Date.parse(e) / 1e3,
        a = new Date,
        a = Date.parse(a) / 1e3,
        t = e - a,
        o = Math.floor(t / 86400),
        i = Math.floor((t - 86400 * o) / 3600),
        s = Math.floor((t - 86400 * o - 3600 * i) / 60),
        n = Math.floor(t - 86400 * o - 3600 * i - 60 * s);
    i < "10" && (i = "0" + i), s < "10" && (s = "0" + s), n < "10" && (n = "0" + n), $("#days").html(o + "<span><br></span>"), $("#hours").html(i + "<span><br></span>"), $("#minutes").html(s + "<span><br></span>"), $("#seconds").html(n + "<span><br></span>")
}

function chartInit() {
    $(".chart").easyPieChart({
        trackColor: "#e8e8e8",
        barColor: "#5dba3b",
        size: 260,
        lineWidth: 13,
        scaleColor: "transparent",
        animate: 2500,
        easing: "ease-in"
    }), $(".chart").hasClass("color-1") && ($(".chart.color-1").data("easyPieChart").options.barColor = "#5255c5"), $(".chart").hasClass("color-2") && ($(".chart.color-2").data("easyPieChart").options.barColor = "#5dba3b"), $(".chart").hasClass("color-3") && ($(".chart.color-3").data("easyPieChart").options.barColor = "#ff8b00"), $(".chart").hasClass("color-4") && ($(".chart.color-4").data("easyPieChart").options.barColor = "#ff5157"), $(".chart").hasClass("color-5") && ($(".chart.color-5").data("easyPieChart").options.barColor = "#ffc000"), $(".chart").each(function() {
        var e = $(this).attr("data-percent");
        $(this).closest(".pie-wrap").find(".percent span").html(e);
        $(this).closest(".pie-wrap").find(".percent span").html(e)
    })
}

function chartAnimate() {
    var e = !0;
    $("*").hasClass("pie-wrap") && $(window).on("scroll", function() {
        $(window).scrollTop() > $(".pie-wrap").offset().top - .8 * $(window).height() && e && (e = !1, $(".chart").each(function() {
            var e = $(this).attr("data-percent-end"),
                a = $(this).closest(".pie-wrap").find(".percent span").html(e);
            $(this).data("easyPieChart").update(e), $({
                numberValue: 0
            }).animate({
                numberValue: e
            }, {
                duration: 2500,
                easing: "linear",
                step: function(e) {
                    a.html(Math.ceil(e))
                }
            })
        }))
    })
}

function moveElement() {
    $("[data-parent-move]").each(function() {
        function e(e, o, i) {
            s.on("mousemove", function(s) {
                if (s.target.closest("[data-parent-move]")) {
                    var n = s.target.closest("[data-parent-move]"),
                        r = n.getBoundingClientRect(),
                        l = (s.clientX, r.left, s.clientY - r.top);
                    "plus" == e.attr("data-move") ? (a = -1 * s.pageX / e.attr("data-move-speed"), t = -1 * l / e.attr("data-move-speed"), moveSide(e, a, t, o, i)) : (a = 1 * s.pageX / e.attr("data-move-speed"), t = 1 * l / e.attr("data-move-speed"), moveSide(e, a, t, o, i))
                }
            })
        }
        var a, t, o, i, s = $(this);
        $(this).find("[data-move]");
        $(this).on("mouseenter", function() {
            $(this).find("[data-move]").each(function() {
                o = parseInt($(this).css("left"), 10), i = parseInt($(this).css("top"), 10), e($(this), o, i)
            })
        })
    })
}

function moveSide(e, a, t, o, i) {
    e.css({
        transform: "translate(" + a + "px," + t + "px)",
        transition: "all .2s",
        "transition-timing-function": "ease-out"
    })
}

function scrollParallax() {
    $("*").hasClass("parallax-img") && $(".parallax-img").each(function() {
        $(this).parent().css({
            "overflow-x": "hidden"
        });
        var e = $(this),
            a = parseInt(e.css("transform").split(",")[4]),
            t = $(this).offset().top,
            o = $(window).height(),
            i = function(i) {
                a += i, e.css("transform", "translateX(" + (a + t - o) / 2 + "px)")
            },
            s = 0;
        a = isNaN(a) ? 0 : a, $(window).on("scroll", function(e) {
            var a = $(window).scrollTop() - s;
            i(-a), s = $(window).scrollTop()
        })
    })
}

function animateCoutt() {
    var e = !0;
    $("*").hasClass("skills-section") && $(window).on("scroll", function() {
        $(window).scrollTop() > $(".skills-section").offset().top - .8 * $(window).height() && e && (e = !1, $(".skills-section [data-skill]").each(function() {
            var e = $(this).attr("data-skill"),
                a = $(this).find(".skill-number");
            $(this).addClass("show-count"), $({
                numberValue: 0
            }).animate({
                numberValue: e
            }, {
                duration: 2500,
                easing: "linear",
                step: function(e) {
                    a.html(Math.ceil(e))
                }
            })
        }))
    })
}

function customSelect() {
    function e(e) {
        if (!e.id) return e.text;
        var a = $(e.element).data("icon");
        if (a) {
            return $("<span><i class='mdi " + a + "'></i>" + $(e.element).text() + "</span>")
        }
        return e.text
    }
    $("select").select2({
        width: "100%",
        templateResult: e,
        templateSelection: e
    }), $('b[role="presentation"]').hide(), $(".select2-selection__arrow").append('<i class="mdi mdi-chevron-down"></i>')
}

function dataPick() {
    $(".choose-data").daterangepicker({
        singleDatePicker: !0,
        showDropdowns: !0,
        minYear: 2017,
        maxYear: 2020,
        locale: {
            format: "DD.MM.YYYY"
        }
    }), $(".choose-data").val("Date")
}

function initMap() {
    function e(e) {
        new google.maps.Marker({
            position: e.coordinates,
            map: e.myMap,
            icon: e.iconImg
        })
    }
    var a, t, o, i, s, n;
    $("*").is("#map") && (a = document.getElementById("map")), $("*").is("#location-map") && (o = document.getElementById("location-map")), $("*").is("#footer-map") && (s = document.getElementById("footer-map"));
    var r = {
        zoom: 16,
        center: {
            lat: 6.693927,
            lng: -1.558710
        },
        styles: [{
            featureType: "water",
            elementType: "all",
            stylers: [{
                hue: "#7fc8ed"
            }, {
                saturation: 55
            }, {
                lightness: -6
            }, {
                visibility: "on"
            }]
        }]
    };
    if ($("*").is("#location-map")) {
        i = new google.maps.Map(o, r);
        for (var l = [{
            coordinates: {
                lat: 6.693927,
                lng: -1.558710
            },
            myMap: i,
            iconImg: 'https://lhsgh.com/img/map-marker.png'
        }], c = 0; c < l.length; c++) e(l[c])
    }
    if ($("*").is("#map")) {
        t = new google.maps.Map(a, r);
        for (var l = [{
            coordinates: {
                lat: 6.693927,
                lng: -1.558710
            },
            myMap: t,
            iconImg: 'https://lhsgh.com/img/map-marker.png'
        }], c = 0; c < l.length; c++) e(l[c])
    }
    if ($("*").is("#footer-map")) {
        n = new google.maps.Map(s, r);
        for (var l = [{
            coordinates: {
                lat: 6.693927,
                lng: -1.558710
            },
            myMap: n,
            iconImg: 'https://lhsgh.com/img/map-marker.png'
        }], c = 0; c < l.length; c++) e(l[c])
    }
}

function backTop() {
    var e = $("#toTop");
    e.outerHeight(!0), $(window).height();
    $(window).on("scroll", function() {
        $(window).scrollTop() >= 400 ? e.addClass("show_btn") : e.removeClass("show_btn")
    }), e.on("click", function() {
        $("html, body").animate({
            scrollTop: 0
        }, 600)
    })
}

function featherlightChange() {
    $("[data-featherlight]").on("click", function() {
        $(".featherlight-close-icon.featherlight-close").html("<i class='mdi mdi-window-close'>")
    })
}

function tableShadow() {
    if ($("*").hasClass("timetable-body")) {
        var e = $(".timetable-body").offset().left,
            a = $(".inner-timetable-wrap").width(),
            t = $(".inner-timetable-wrap .timetable-body").width(),
            o = t - a;
        a + 15 < t && $(".right-shadow").addClass("shadow"), $(".timetable-wrap").on("scroll", function() {
            var i = $(this);
            if (e = $(".timetable-body").offset().left, e < 15 ? ($(".left-shadow").addClass("shadow"), 15 - e <= 15 && $(".left-shadow").css({
                    width: 15 - e + "px"
                })) : $(".left-shadow").removeClass("shadow"), i.scrollLeft() >= o) $(".right-shadow").removeClass("shadow");
            else {
                var s = t - a - i.scrollLeft();
                $(".right-shadow").addClass("shadow"), $(".right-shadow").css({
                    width: s + "px"
                })
            }
        })
    }
}

function initEvents() {
    $(function() {
        sliderInit(), mobileNav(), mobileSearch(), animateScroll(), progressAnimation(), makeTimer(), chartInit(), moveElement(), scrollParallax(), animateCoutt(), chartAnimate(), customSelect(), dataPick(), backTop(), featherlightChange(), tableShadow()
    }), $(window).on("load", function() {
        $(".preloader-container").fadeOut(500)
    })
}
setInterval(function() {
    makeTimer()
}, 1e3), initEvents();