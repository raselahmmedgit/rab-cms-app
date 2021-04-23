/**
* Template Name: Arsha - v2.3.0
* Template URL: https://bootstrapmade.com/arsha-free-bootstrap-html-template-corporate/
* Author: BootstrapMade.com
* License: https://bootstrapmade.com/license/
*/
!(function ($) {
    "use strict";

    // Smooth scroll for the navigation menu and links with .scrollto classes
    var scrolltoOffset = $('#header').outerHeight() - 2;
    $(document).on('click', '.nav-menu a, .mobile-nav a, .scrollto', function (e) {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            if (target.length) {
                e.preventDefault();

                var scrollto = target.offset().top - scrolltoOffset;
                if ($(this).attr("href") == '#header') {
                    scrollto = 0;
                }

                $('html, body').animate({
                    scrollTop: scrollto
                }, 1500, 'easeInOutExpo');

                if ($(this).parents('.nav-menu, .mobile-nav').length) {
                    $('.nav-menu .active, .mobile-nav .active').removeClass('active');
                    $(this).closest('li').addClass('active');
                }

                if ($('body').hasClass('mobile-nav-active')) {
                    $('body').removeClass('mobile-nav-active');
                    $('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
                    $('.mobile-nav-overly').fadeOut();
                }
                return false;
            }
        }
    });
    
    // Activate smooth scroll on page load with hash links
    $(document).ready(function () {
        if (window.location.hash) {
            var initial_nav = window.location.hash;
            if ($(initial_nav).length) {
                var scrollto = $(initial_nav).offset().top - scrolltoOffset;
                $('html, body').animate({
                    scrollTop: scrollto
                }, 500, 'easeInOutExpo');
            }
        }
    });
    $(document).ready(function () { var o; $(".social-nav .dropdown button, .dropdown-menu").hover(function () { clearTimeout(o), $(".social-nav .dropdown-menu").addClass("show") }, function () { o = setTimeout(function () { $(".social-nav .dropdown-menu").removeClass("show") }, 500) }) });
    // Mobile Navigation
    if ($('.nav-menu').length) {
        var $mobile_nav = $('.nav-menu').clone().prop({
            class: 'mobile-nav d-lg-none'
        });

        $('body').append($mobile_nav);

       function shoHideMobileMenu() {
           if ($('body').hasClass('mobile-nav-active')) {
               $('body').removeClass('mobile-nav-active');
               $('.mobile-nav-overly').hide();
           } else {
               $('body').addClass('mobile-nav-active');
               $('.mobile-nav-overly').show();
           } $('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
       };

        $(document).on('click', '.mobile-nav-toggle', function (e) {
            shoHideMobileMenu();
        });
        $('.mobile-nav-overly').click(function (e) {
            shoHideMobileMenu();
        });
        $(document).on('click', '.mobile-nav .drop-down .up-down', function (e) {
            e.preventDefault();
            $(this).parent().next().slideToggle(300);
            $(this).parent().parent().toggleClass('active');
            $(this).find('i').toggleClass('icofont-rounded-down icofont-rounded-up');
        });

    } else if ($(".mobile-nav, .mobile-nav-toggle").length) {
        $(".mobile-nav, .mobile-nav-toggle").hide();
    }

    // Navigation active state on scroll
    var nav_sections = $('section');
    var main_nav = $('.nav-menu, #mobile-nav');

    $(window).on('scroll', function () {
        var cur_pos = $(this).scrollTop() + 200;

        nav_sections.each(function () {
            var top = $(this).offset().top,
                bottom = top + $(this).outerHeight();

            if (cur_pos >= top && cur_pos <= bottom) {
                if (cur_pos <= bottom) {
                    main_nav.find('li').removeClass('active');
                }
                main_nav.find('a[href="#' + $(this).attr('id') + '"]').parent('li').addClass('active');
            }
            if (cur_pos < 300) {
                $(".nav-menu ul:first li:first").addClass('active');
            }
        });
    });

    // Toggle .header-scrolled class to #header when page is scrolled
    $(window).scroll(function () {
        var $header = $('#header');
        if ($(this).scrollTop() > 40) {
            $header.addClass('header-scrolled');
            $header.addClass('fixed-top');
        } else {
            $header.removeClass('header-scrolled');
            $header.removeClass('fixed-top');
        }
    });

    if ($(window).scrollTop() > 100) {
        $('#header').addClass('header-scrolled');
    }

    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });

    $('.back-to-top').click(function () {
        $('html, body').animate({
            scrollTop: 0
        }, 1500, 'easeInOutExpo');
        return false;
    });

    // Skills section
    $('.skills-content').waypoint(function () {
        $('.progress .progress-bar').each(function () {
            $(this).css("width", $(this).attr("aria-valuenow") + '%');
        });
    }, {
        offset: '80%'
    });



    // Testimonials carousel (uses the Owl Carousel library)
    $(".testimonials-carousel").owlCarousel({
        autoplay: true,
        dots: true,
        loop: true,
        items: 1
    });

    // Porfolio isotope and filter
    $(window).on('load', function () {
        var portfolioIsotope = $('.portfolio-container').isotope({
            itemSelector: '.portfolio-item'
        });

        $('#portfolio-flters li').on('click', function () {
            $("#portfolio-flters li").removeClass('filter-active');
            $(this).addClass('filter-active');

            portfolioIsotope.isotope({
                filter: $(this).data('filter')
            });
            aos_init();
        });

        // Initiate venobox (lightbox feature used in portofilo)
        $(document).ready(function () {
            $('.venobox').venobox({
                'share': false
            });
        });
    });

    // Portfolio details carousel
    $(".portfolio-details-carousel").owlCarousel({ autoplay: true, dots: true, loop: true, items: 1 });

    // Init 
    function aos_init() { AOS.init({ duration: 500, once: true }); }
    function lazy_init() { $("img.lazy").Lazy(); $("video.lazy").lazy(); $("iframe.lazy").lazy(); $("section.lazy").lazy(); }
    $(window).on('load', function () { aos_init(); lazy_init(); });

})(jQuery);