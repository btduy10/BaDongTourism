/* BaDong Tourism - Main JS */

document.addEventListener('DOMContentLoaded', function () {

    // AOS init
    AOS.init({ duration: 700, once: true, offset: 80 });

    // Fix orphan syllable: thay dau cach cuoi cung trong hero-title bang &nbsp;
    // de am tiet cuoi khong bi nhay xuong hang mot minh (tieng Viet)
    document.querySelectorAll('.hero-title').forEach(function (el) {
        // Chi xu ly text node, tranh lam hong <br/> neu co
        if (el.childNodes.length === 1 && el.childNodes[0].nodeType === 3) {
            var t = el.textContent;
            var last = t.lastIndexOf(' ');
            if (last > 0) {
                el.innerHTML = t.substring(0, last) + '&nbsp;' + t.substring(last + 1);
            }
        } else {
            // Co the co <br/> hoac nhieu node - xu ly node cuoi
            var nodes = el.childNodes;
            for (var i = nodes.length - 1; i >= 0; i--) {
                if (nodes[i].nodeType === 3 && nodes[i].textContent.trim() !== '') {
                    var txt = nodes[i].textContent;
                    var sp = txt.lastIndexOf(' ');
                    if (sp > 0) {
                        var span = document.createElement('span');
                        span.innerHTML = txt.substring(0, sp) + '&nbsp;' + txt.substring(sp + 1);
                        el.replaceChild(span, nodes[i]);
                    }
                    break;
                }
            }
        }
    });

    // Navbar scroll effect
    const nav = document.getElementById('mainNav');
    if (nav) {
        window.addEventListener('scroll', function () {
            nav.classList.toggle('scrolled', window.scrollY > 50);
        });
    }

    // Active nav link
    const currentPath = window.location.pathname.toLowerCase();
    document.querySelectorAll('#mainNav .nav-link').forEach(function (link) {
        const href = link.getAttribute('href');
        if (href && currentPath.includes(href.replace('~/', '').toLowerCase().split('.')[0])) {
            link.classList.add('active');
        }
    });

    // Hero Swiper
    const heroSwiper = document.querySelector('.hero-swiper');
    if (heroSwiper) {
        const swiper = new Swiper(heroSwiper, {
            loop: true,
            autoplay: { delay: 5000, disableOnInteraction: false },
            effect: 'fade',
            fadeEffect: { crossFade: true },
            pagination: { el: '.swiper-pagination', clickable: true },
            speed: 1000
        });
    }

    // Gallery Swiper (thumbnail)
    if (document.querySelector('.gallery-swiper')) {
        new Swiper('.gallery-swiper', {
            loop: true,
            slidesPerView: 1,
            spaceBetween: 0,
            navigation: { nextEl: '.swiper-button-next', prevEl: '.swiper-button-prev' },
            pagination: { el: '.swiper-pagination', clickable: true }
        });
    }

    // Back to top
    const btt = document.getElementById('backToTop');
    if (btt) {
        window.addEventListener('scroll', function () {
            btt.classList.toggle('show', window.scrollY > 300);
        });
        btt.addEventListener('click', function (e) {
            e.preventDefault();
            window.scrollTo({ top: 0, behavior: 'smooth' });
        });
    }

    // Counter animation
    document.querySelectorAll('.stat-number[data-target]').forEach(function (el) {
        const target = parseInt(el.getAttribute('data-target'));
        const obs = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    animateCounter(el, target);
                    obs.unobserve(el);
                }
            });
        });
        obs.observe(el);
    });

    function animateCounter(el, target) {
        let current = 0;
        const step = Math.ceil(target / 60);
        const timer = setInterval(function () {
            current += step;
            if (current >= target) { current = target; clearInterval(timer); }
            el.textContent = current.toLocaleString('vi-VN') + (el.dataset.suffix || '');
        }, 25);
    }

    // Lightbox for gallery
    document.querySelectorAll('.gallery-item').forEach(function (item) {
        item.addEventListener('click', function () {
            const img = item.querySelector('img');
            if (!img) return;
            const modal = document.createElement('div');
            modal.style.cssText = 'position:fixed;inset:0;background:rgba(0,0,0,0.9);z-index:9999;display:flex;align-items:center;justify-content:center;cursor:zoom-out;';
            modal.innerHTML = '<img src="' + img.src + '" style="max-width:90%;max-height:90vh;border-radius:8px;box-shadow:0 8px 40px rgba(0,0,0,0.5);" />';
            modal.addEventListener('click', function () { modal.remove(); });
            document.body.appendChild(modal);
        });
    });

    // Tour price calculator
    const nguoiLonInput = document.getElementById('SoNguoiLon');
    const treEmInput    = document.getElementById('SoTreEm');
    const tongTienEl    = document.getElementById('TongTien');

    if (nguoiLonInput && tongTienEl) {
        function calcTotal() {
            const giaNL  = parseFloat(tongTienEl.dataset.gianguoilon || 0);
            const giaTE  = parseFloat(tongTienEl.dataset.giatreem || 0);
            const soNL   = parseInt(nguoiLonInput.value || 0);
            const soTE   = treEmInput ? parseInt(treEmInput.value || 0) : 0;
            const total  = soNL * giaNL + soTE * giaTE;
            tongTienEl.value = total;
            const display = document.getElementById('TongTienDisplay');
            if (display) display.textContent = total.toLocaleString('vi-VN') + 'đ';
        }
        nguoiLonInput.addEventListener('change', calcTotal);
        if (treEmInput) treEmInput.addEventListener('change', calcTotal);
        calcTotal();
    }

    // Form validation bootstrap
    document.querySelectorAll('.needs-validation').forEach(function (form) {
        form.addEventListener('submit', function (e) {
            if (!form.checkValidity()) {
                e.preventDefault();
                e.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    });

});
