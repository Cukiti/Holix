using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Holix.Models;
using Holix.Data;
using Microsoft.EntityFrameworkCore;

namespace Holix.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Seed services, faqs, testimonials if empty
        if (!await _context.Services.AnyAsync() || !await _context.Services.AnyAsync(s => !string.IsNullOrEmpty(s.Slug)))
        {
            _context.Services.RemoveRange(_context.Services);
            await _context.SaveChangesAsync();
            _context.Services.AddRange(
                new Service
                {
                    Title = "UI/UX Creative Design",
                    Slug = "ui-ux-creative-design",
                    Description = "Designing intuitive and stunning user interfaces.",
                    FullDescription = "<h2>Crafting Experiences That Connect</h2><p>UI/UX design is about far more than making things look pretty — it is about creating intuitive, accessible, and delightful experiences that guide users effortlessly toward their goals. Our design process begins with deep user research to understand motivations, pain points, and behaviors before a single pixel is placed.</p><h3>Research-Driven Design</h3><p>We conduct user interviews, competitive audits, and usability testing to ground every design decision in real data. This research phase ensures that the interfaces we build solve actual problems rather than assumed ones. Our team synthesizes findings into user personas and journey maps that inform the entire design process.</p><h3>Wireframing and Prototyping</h3><p>From low-fidelity wireframes to high-fidelity interactive prototypes, we iterate rapidly to validate concepts before development begins. Tools like Figma and Framer allow us to create clickable prototypes that feel like the real product, enabling stakeholders and users to provide meaningful feedback early in the process.</p><h2>Visual Design and Brand Integration</h2><p>Every visual element — from typography and color to spacing and motion — is purposefully chosen to reinforce your brand identity while maximizing usability. We design responsive interfaces that look and feel native across every device, from mobile phones to large desktop displays.</p><h2>Measuring Success</h2><p>Our work doesn't end at launch. We establish baseline metrics for key UX indicators — task completion rate, time on task, error rate, and user satisfaction — then measure improvement after each design iteration. Our clients typically see 40-60% improvement in core usability metrics within the first quarter.</p>",
                    Icon = "fa-solid fa-palette",
                    ImageUrl = "https://picsum.photos/seed/service1/800/500"
                },
                new Service
                {
                    Title = "App Development",
                    Slug = "app-development",
                    Description = "Native and cross-platform mobile applications.",
                    FullDescription = "<h2>Building Powerful Mobile Experiences</h2><p>Mobile applications are the primary way most users interact with digital services today. Whether you need a native iOS or Android app, or a cross-platform solution that reaches both ecosystems simultaneously, our development team has the expertise to deliver exceptional results.</p><h3>Cross-Platform with Native Performance</h3><p>We leverage Flutter and React Native to build apps that run beautifully on both iOS and Android from a single codebase, without sacrificing performance. Our cross-platform apps achieve 95%+ code sharing while maintaining native look, feel, and performance on each platform.</p><h3>Native Development</h3><p>For projects that demand platform-specific features — ARKit, advanced camera controls, or deep system integrations — we build native apps using Swift for iOS and Kotlin for Android. Native development provides unrestricted access to platform APIs and the highest possible performance.</p><h2>Full Lifecycle Management</h2><p>From concept and architecture through development, testing, deployment, and ongoing maintenance, we manage the entire app lifecycle. Our CI/CD pipelines ensure rapid, reliable releases, and we provide post-launch analytics and monitoring to keep your app performing at its best.</p><h2>Real-World Results</h2><p>The apps we build consistently achieve 4.5+ star ratings on app stores. Our clients report average user retention improvements of 35% after launch, with many apps reaching top rankings in their categories within the first quarter.</p>",
                    Icon = "fa-solid fa-mobile-screen",
                    ImageUrl = "https://picsum.photos/seed/service2/800/500"
                },
                new Service
                {
                    Title = "Professional Content Writer",
                    Slug = "professional-content-writer",
                    Description = "Compelling copy that drives conversions.",
                    FullDescription = "<h2>Words That Drive Action</h2><p>Great content is the bridge between your brand and your audience. Our professional copywriters craft compelling narratives that capture attention, build trust, and drive conversions across every channel — from website copy and blog posts to email campaigns and social media.</p><h3>SEO-Optimized Content</h3><p>Every piece of content we produce is optimized for search engines without sacrificing readability or brand voice. We conduct thorough keyword research, structure content for featured snippets, and follow Google's E-E-A-T guidelines to help your pages rank higher and attract qualified organic traffic.</p><h3>Brand Voice Development</h3><p>We work closely with your team to define and document a distinctive brand voice that sets you apart from competitors. Whether your brand is professional and authoritative or friendly and conversational, we ensure consistency across every piece of content your audience encounters.</p><h2>Content Strategy and Planning</h2><p>Beyond individual pieces, we develop comprehensive content strategies that align with your business goals. This includes editorial calendars, pillar page strategies, content gap analysis, and performance measurement frameworks that ensure your content investment delivers measurable ROI.</p><h2>Proven Impact</h2><p>Our content clients see an average 180% increase in organic traffic within six months, with many achieving first-page rankings for competitive keywords. Blog content we produce generates 3x more leads than paid advertising for the same investment.</p>",
                    Icon = "fa-solid fa-pen-nib",
                    ImageUrl = "https://picsum.photos/seed/service3/800/500"
                },
                new Service
                {
                    Title = "Graphic Design",
                    Slug = "graphic-design",
                    Description = "Visual identities that leave a lasting mark.",
                    FullDescription = "<h2>Visual Identity That Stands Out</h2><p>In a crowded marketplace, your visual identity is often the first — and most lasting — impression you make on potential customers. Our graphic design team creates cohesive, memorable visual systems that communicate your brand's values and personality at every touchpoint.</p><h3>Logo and Brand Identity</h3><p>We design versatile logo systems that work across digital, print, and environmental applications. Each identity includes primary and secondary logos, color palettes, typography systems, iconography, and comprehensive brand guidelines that ensure consistent application across your entire organization.</p><h3>Print and Digital Design</h3><p>From business cards and brochures to social media templates and presentation decks, we create visually compelling assets that maintain brand consistency across all media. Our designs are production-ready, with proper color profiles, bleeds, and file formats for every output channel.</p><h2>Packaging and Environmental Design</h2><p>For physical products, we design packaging that captures attention on crowded shelves and communicates product value instantly. We also create environmental graphics for retail spaces, trade show booths, and office environments that immerse visitors in your brand experience.</p><h2>The Results Speak</h2><p>Brands we've worked with report 45% average improvement in brand recall after implementing our visual identity systems. Our packaging designs have helped clients achieve 30%+ shelf impact increases and multiple industry design awards.</p>",
                    Icon = "fa-solid fa-vector-square",
                    ImageUrl = "https://picsum.photos/seed/service4/800/500"
                }
            );
            _context.FaqItems.AddRange(
                new FaqItem { Question = "What does a UX strategy include?", Answer = "Research, wireframing, user testing, and final high-fidelity design.", Order = 1 },
                new FaqItem { Question = "How long does app development take?", Answer = "Depending on complexity, an app can take anywhere from 2 to 6 months.", Order = 2 },
                new FaqItem { Question = "Do you provide ongoing support?", Answer = "Yes, we offer maintenance packages to keep your platform updated.", Order = 3 }
            );
            _context.Testimonials.AddRange(
                new Testimonial { ClientName = "Sarah Jenkins", Company = "TechFlow", Content = "Holix transformed our digital presence completely. Outstanding work!", Rating = 5, AvatarUrl = "https://i.pravatar.cc/150?img=47" },
                new Testimonial { ClientName = "Mark Stevenson", Company = "LogixCorp", Content = "Their team is incredibly professional and delivered beyond expectations.", Rating = 5, AvatarUrl = "https://i.pravatar.cc/150?img=11" }
            );
            await _context.SaveChangesAsync();
        }

        // Seed 15 projects if fewer than 15
        if (!await _context.Projects.AnyAsync() || await _context.Projects.CountAsync() < 15)
        {
            _context.Projects.RemoveRange(_context.Projects);
            await _context.SaveChangesAsync();
            var rng = new Random();
            var allSeedProjects = new List<Project>
            {
                new()
                {
                    Title = "ShopWave E-Commerce Platform",
                    Slug = "shopwave-ecommerce-platform",
                    Client = "NexGen Retail Inc.",
                    Category = "E-Commerce",
                    Technologies = "Next.js, Stripe, PostgreSQL, Redis",
                    Excerpt = "A high-performance e-commerce platform handling 50k+ daily transactions with real-time inventory and personalized recommendations.",
                    Description = "<h2>Revolutionizing Online Retail</h2><p>ShopWave was built to handle peak traffic loads of 10,000 concurrent users while maintaining sub-second page load times. The platform features a headless architecture that decouples the frontend from the backend, allowing for rapid iteration and A/B testing.</p><h3>Personalized Shopping Experience</h3><p>Using machine learning algorithms, ShopWave delivers personalized product recommendations based on browsing history, purchase patterns, and seasonal trends. This resulted in a 34% increase in average order value.</p><h2>Real-Time Inventory Management</h2><p>Built on a real-time event-driven architecture using Redis and WebSockets, the inventory system updates across all channels instantaneously. This eliminated overselling and reduced fulfillment errors by 98%.</p><p>The platform processed over $12M in transactions in its first quarter, exceeding all performance targets set by the client.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj1/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "VaultPay Mobile Banking App",
                    Slug = "vaultpay-mobile-banking-app",
                    Client = "Vault Financial Group",
                    Category = "Mobile App",
                    Technologies = "React Native, Node.js, MongoDB, AWS",
                    Excerpt = "A secure, intuitive mobile banking application with biometric authentication, real-time notifications, and AI-powered spending insights.",
                    Description = "<h2>Banking Reimagined</h2><p>VaultPay brings enterprise-grade banking security to mobile devices with a consumer-friendly interface. The app supports multiple account types, fund transfers, bill payments, and investment tracking in a single unified experience.</p><h3>AI-Powered Financial Insights</h3><p>Integrated machine learning models analyze spending patterns to provide personalized budgeting advice, detect unusual transactions, and forecast future balances. Users reported a 27% improvement in savings after three months of use.</p><h2>Security First Architecture</h2><p>Biometric authentication, end-to-end encryption, and real-time fraud detection ensure that every transaction is protected. The app achieved SOC 2 Type II certification within six months of launch.</p><p>With over 100,000 downloads in the first month, VaultPay became the fastest-growing banking app in the region.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj2/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "Brand Identity Redesign for Lumina",
                    Slug = "lumina-brand-identity-redesign",
                    Client = "Lumina Cosmetics",
                    Category = "Branding",
                    Technologies = "Adobe Creative Suite, Figma, After Effects",
                    Excerpt = "A complete brand identity overhaul including logo, packaging, digital presence, and brand guidelines for a premium cosmetics company.",
                    Description = "<h2>A Fresh Vision for Beauty</h2><p>Lumina approached us with a desire to modernize their 15-year-old brand identity while retaining the equity built over years of customer loyalty. We conducted extensive market research and customer interviews to inform the creative direction.</p><h3>Visual Identity System</h3><p>The new identity features a refined logo system, an expanded color palette inspired by natural elements, custom typography, and a comprehensive set of brand assets that work across print, digital, and environmental applications.</p><h2>Digital-First Brand Experience</h2><p>We redesigned the e-commerce site and social media presence to reflect the new identity, resulting in a 52% increase in time on site and a 38% improvement in conversion rate across all digital channels.</p><p>The rebrand was featured in Communication Arts and received the 2025 Design Excellence Award for Brand Identity.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj3/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "DataPulse SaaS Dashboard",
                    Slug = "datapulse-saas-dashboard",
                    Client = "DataPulse Analytics",
                    Category = "SaaS",
                    Technologies = "React, D3.js, Python, FastAPI, TimescaleDB",
                    Excerpt = "A real-time analytics dashboard processing millions of data points per second with interactive visualizations and customizable reporting.",
                    Description = "<h2>Real-Time Analytics at Scale</h2><p>DataPulse is a full-featured SaaS platform that ingests, processes, and visualizes streaming data from hundreds of sources. The system handles over 5 million events per second with sub-100ms query latency.</p><h3>Interactive Visualization Engine</h3><p>Built with D3.js and WebGL, the visualization engine supports complex charts, heatmaps, geographic maps, and custom dashboard layouts. Users can drill down from high-level metrics to individual data points with zero lag.</p><h2>Enterprise-Grade Features</h2><p>Role-based access control, scheduled report generation, webhook integrations, and a RESTful API make DataPulse suitable for enterprises of any size. The platform achieved 99.99% uptime in its first year of operation.</p><p>DataPulse grew from 50 to 2,000+ paying customers within 18 months of launch, with an NPS score of 72.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj4/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "Saboré Restaurant Website",
                    Slug = "sabore-restaurant-website",
                    Client = "Saboré Dining Group",
                    Category = "Web Design",
                    Technologies = "Gatsby, WordPress, GSAP, Cloudflare",
                    Excerpt = "An immersive restaurant website featuring a dynamic menu system, online reservations, and stunning food photography with smooth animations.",
                    Description = "<h2>A Feast for the Eyes</h2><p>Saboré required a website that captured the sensory experience of dining at their award-winning restaurant. We created a visually rich site with full-screen hero imagery, parallax scrolling effects, and micro-animations that bring the brand to life.</p><h3>Dynamic Menu System</h3><p>The menu updates in real-time from a headless CMS, supporting seasonal rotations, dietary filters, and multilingual descriptions. Each dish features professional photography that loads progressively for optimal performance.</p><h2>Seamless Reservation Experience</h2><p>Integrated with OpenTable for real-time table availability, the reservation flow is frictionless and mobile-optimized. The site also handles private event bookings and gift card purchases.</p><p>Since launch, online reservations have increased by 67% and the site has been recognized by Awwwards for outstanding design and user experience.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj5/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "HomeVista Real Estate Portal",
                    Slug = "homevista-real-estate-portal",
                    Client = "HomeVista Properties",
                    Category = "Web Platform",
                    Technologies = "Angular, .NET Core, SQL Server, Azure Maps",
                    Excerpt = "A comprehensive real estate platform with virtual tours, AI-powered property matching, and a complete agent management system.",
                    Description = "<h2>Finding the Perfect Home</h2><p>HomeVista aggregates listings from hundreds of agencies and private sellers, providing a single platform for property seekers. The platform handles 500,000+ active listings with advanced search and filtering capabilities.</p><h3>AI Property Matching</h3><p>Our recommendation engine analyzes user preferences, search history, and behavior patterns to suggest properties that match criteria beyond basic filters. This feature increased engagement by 40% and reduced time-to-offer by 25%.</p><h2>Virtual Tour Integration</h2><p>360-degree virtual tours with embedded floor plans and neighborhood information allow buyers to explore properties remotely. Sellers reported 3x more qualified leads after implementing virtual tours.</p><p>HomeVista became the region's fastest-growing real estate platform, reaching 1 million monthly active users within one year.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj6/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "FitPulse Fitness Tracking App",
                    Slug = "fitpulse-fitness-tracking-app",
                    Client = "FitPulse Health Inc.",
                    Category = "Mobile App",
                    Technologies = "Flutter, Firebase, TensorFlow Lite, HealthKit",
                    Excerpt = "A cross-platform fitness tracking app with AI-powered workout recognition, social challenges, and integration with wearable devices.",
                    Description = "<h2>Your Personal Fitness Companion</h2><p>FitPulse combines activity tracking, workout planning, nutrition logging, and social motivation in a single beautiful app. The app uses on-device machine learning to automatically recognize exercises and count repetitions.</p><h3>AI Workout Recognition</h3><p>Using TensorFlow Lite, the app can identify over 80 different exercises from accelerometer and gyroscope data. Users simply start moving and FitPulse tracks everything automatically with 94% accuracy.</p><h2>Social Fitness Challenges</h2><p>Users can create or join challenges, compete on leaderboards, share achievements, and support friends. This social layer increased daily active usage by 55% and improved 30-day retention by 40%.</p><p>FitPulse achieved 500,000 downloads in the first quarter and was featured as a top health app on both iOS and Android app stores.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj7/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "GrowthHive Digital Marketing Campaign",
                    Slug = "growthhive-digital-marketing-campaign",
                    Client = "GrowthHive Agency",
                    Category = "Marketing",
                    Technologies = "Google Ads, Meta Ads, HubSpot, Tableau",
                    Excerpt = "A data-driven multi-channel marketing campaign that generated 300% ROI across paid search, social media, and email marketing channels.",
                    Description = "<h2>Data-Driven Marketing at Scale</h2><p>We designed and executed a comprehensive digital marketing campaign for GrowthHive's SaaS product launch. The campaign spanned Google Ads, LinkedIn, Meta, and email marketing, all coordinated through a unified analytics dashboard.</p><h3>Multi-Channel Attribution</h3><p>Using a custom attribution model, we tracked the customer journey across all touchpoints and optimized budget allocation in real-time. This approach reduced cost per lead by 45% while maintaining lead quality.</p><h2>Creative Strategy and A/B Testing</h2><p>We produced over 200 creative variations across formats and ran continuous A/B tests to identify winning combinations. Data-driven creative optimization improved click-through rates by 3.2x over the campaign average.</p><p>The campaign generated 8,500 qualified leads and $4.2M in attributed revenue over six months, achieving a 3.2x return on ad spend.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj8/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "ApexCorp Corporate Website Redesign",
                    Slug = "apexcorp-corporate-website-redesign",
                    Client = "ApexCorp Industries",
                    Category = "Web Design",
                    Technologies = "Next.js, Sanity CMS, Framer Motion, Vercel",
                    Excerpt = "A complete corporate website redesign for a Fortune 500 industrial company, featuring a modular component system and sub-second page loads.",
                    Description = "<h2>Modernizing a Corporate Giant</h2><p>ApexCorp's previous website was built on a legacy CMS that limited design flexibility and performance. We migrated the entire site to a modern JAMstack architecture, achieving perfect Lighthouse scores across all pages.</p><h3>Modular Component Library</h3><p>We built a reusable component library with over 50 modules that the marketing team can mix and match to create new pages without developer involvement. This reduced page creation time from weeks to hours.</p><h2>Performance and Accessibility</h2><p>The new site loads in under 800ms on mobile networks and achieves WCAG 2.1 AA compliance. Core Web Vitals scores rank in the 99th percentile, contributing to improved SEO performance and user satisfaction.</p><p>Organic traffic increased by 85% following the relaunch, and the site now serves as a template for ApexCorp's subsidiary brands worldwide.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj9/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "QuickBite Food Delivery App",
                    Slug = "quickbite-food-delivery-app",
                    Client = "QuickBite Technologies",
                    Category = "Mobile App",
                    Technologies = "Swift, Kotlin, Node.js, Socket.IO, MongoDB",
                    Excerpt = "A real-time food delivery platform with live order tracking, smart routing, and an AI-powered recommendation engine for personalized meal suggestions.",
                    Description = "<h2>Delivering Delight</h2><p>QuickBite connects hungry customers with local restaurants through a seamless ordering experience. The platform handles real-time order tracking, driver dispatch, and payment processing across thousands of concurrent orders.</p><h3>Smart Routing and Dispatch</h3><p>Our proprietary routing algorithm considers traffic patterns, restaurant preparation times, and driver locations to minimize delivery times. Average delivery time dropped by 22% compared to the previous system.</p><h2>Personalized Recommendations</h2><p>An AI recommendation engine analyzes order history, dietary preferences, and even weather conditions to suggest meals. This feature increased average order value by 18% and reduced decision paralysis.</p><p>QuickBite expanded to 15 cities within its first year, processing over 2 million orders with a customer satisfaction rating of 4.7 stars.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj10/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "Wanderlust Travel Booking Platform",
                    Slug = "wanderlust-travel-booking-platform",
                    Client = "Wanderlust Travel Co.",
                    Category = "Web Platform",
                    Technologies = "Vue.js, Go, GraphQL, Elasticsearch, Redis",
                    Excerpt = "A modern travel booking platform with AI trip planning, price prediction, and a comprehensive loyalty program for frequent travelers.",
                    Description = "<h2>Travel Made Intelligent</h2><p>Wanderlust aggregates flight, hotel, and activity data from hundreds of suppliers to offer the best travel combinations. The platform uses machine learning to predict price movements and recommend optimal booking times.</p><h3>AI Trip Planner</h3><p>Users describe their ideal trip in natural language, and the AI planner generates complete itineraries with flights, accommodations, activities, and dining recommendations. This feature increased booking conversion by 35%.</p><h2>Price Prediction Engine</h2><p>Our price prediction model analyzes historical data, seasonality, and market trends to forecast whether prices will rise or fall. Users receive timely notifications when prices drop or when they should book before increases.</p><p>Wanderlust achieved 1 million registered users in its first year and was named one of the top 10 travel startups by TechCrunch.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj11/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "MedConnect Healthcare Portal",
                    Slug = "medconnect-healthcare-portal",
                    Client = "MedConnect Health Systems",
                    Category = "Web Platform",
                    Technologies = "React, .NET, SQL Server, HL7 FHIR, Azure",
                    Excerpt = "A secure patient portal with telemedicine capabilities, electronic health records access, prescription management, and AI-powered symptom checker.",
                    Description = "<h2>Healthcare in Your Hands</h2><p>MedConnect gives patients secure access to their health information, telemedicine consultations, and direct communication with healthcare providers. The platform handles over 500,000 patient records with full HIPAA compliance.</p><h3>Telemedicine Integration</h3><p>Built-in video consultations with screen sharing, digital prescriptions, and integrated payment processing. Providers can see up to 30% more patients per day using MedConnect's streamlined workflow.</p><h2>AI Symptom Checker</h2><p>An AI-powered symptom assessment tool helps patients understand their condition and determine appropriate care levels. The system has a 92% accuracy rate for common conditions and routes urgent cases to emergency care immediately.</p><p>MedConnect was adopted by 25 hospital networks in its first year and reduced patient wait times for non-emergency consultations by 60%.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj12/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "SkillForge Educational Platform",
                    Slug = "skillforge-educational-platform",
                    Client = "SkillForge Learning Inc.",
                    Category = "SaaS",
                    Technologies = "Next.js, Python, PostgreSQL, AWS, WebRTC",
                    Excerpt = "An interactive online learning platform with live classes, AI-powered progress tracking, and a marketplace for course creators.",
                    Description = "<h2>Learning Without Limits</h2><p>SkillForge provides a complete ecosystem for online education, supporting live interactive classes, pre-recorded courses, and hands-on projects. The platform serves over 200,000 active learners across 50+ countries.</p><h3>AI-Powered Learning Paths</h3><p>Our adaptive learning engine analyzes student performance and learning styles to create personalized curriculum paths. Students following AI-recommended paths complete courses 40% faster with 25% higher assessment scores.</p><h2>Creator Marketplace</h2><p>Course creators can build, market, and sell courses with built-in tools for video hosting, assessment creation, and student analytics. Top creators earn over $100,000 annually on the platform.</p><p>SkillForge was recognized as the EdTech Startup of the Year and secured $30M in Series A funding within 18 months of launch.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj13/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "SocialPulse Social Media Dashboard",
                    Slug = "socialpulse-social-media-dashboard",
                    Client = "SocialPulse Inc.",
                    Category = "SaaS",
                    Technologies = "React, Redux, Django, Celery, PostgreSQL",
                    Excerpt = "An enterprise social media management platform with scheduling, analytics, competitor tracking, and AI-powered content generation.",
                    Description = "<h2>Social Media Management at Scale</h2><p>SocialPulse empowers marketing teams to manage multiple social media accounts from a single dashboard. The platform supports scheduling, publishing, engagement tracking, and comprehensive analytics across all major social networks.</p><h3>AI Content Generation</h3><p>Our AI assistant helps create on-brand social media content, from captions to image suggestions, based on brand voice guidelines and campaign objectives. Marketers report saving 15 hours per week using this feature.</p><h2>Competitor Intelligence</h2><p>Track competitor social media performance, content strategies, and audience growth. Benchmark reports provide actionable insights that help users refine their own social media strategy and stay ahead of market trends.</p><p>SocialPulse onboarded over 500 enterprise clients in its first year, including 20 Fortune 500 companies, and processes over 10 million social media posts monthly.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj14/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                },
                new()
                {
                    Title = "MetaVault NFT Marketplace",
                    Slug = "metavault-nft-marketplace",
                    Client = "MetaVault Studios",
                    Category = "Blockchain",
                    Technologies = "Solidity, Web3.js, Next.js, IPFS, The Graph",
                    Excerpt = "A full-featured NFT marketplace with multi-chain support, gas optimization, and a curated digital art collection from emerging artists.",
                    Description = "<h2>The Future of Digital Art</h2><p>MetaVault is a curated NFT marketplace that connects digital artists with collectors. The platform supports Ethereum, Polygon, and Solana, with a focus on gas-efficient minting and eco-friendly transactions.</p><h3>Curated Artist Program</h3><p>Unlike open marketplaces, MetaVault features a rigorous curation process that ensures quality and authenticity. Emerging artists receive mentorship and promotional support, building a strong community of creators and collectors.</p><h2>Multi-Chain Interoperability</h2><p>Users can buy, sell, and trade NFTs across multiple blockchains from a single wallet interface. Our cross-chain bridge enables seamless asset transfers with minimal fees and near-instant confirmation times.</p><p>MetaVault generated over $5M in transaction volume in its first quarter and was featured in Forbes as one of the most innovative NFT platforms of the year.</p>",
                    ImageUrl = "https://picsum.photos/seed/proj15/800/500",
                    CompletedAt = DateTime.UtcNow.AddMonths(-rng.Next(1, 12)),
                    IsPublished = true,
                    Views = rng.Next(80, 3500)
                }
            };
            _context.Projects.AddRange(allSeedProjects);
            await _context.SaveChangesAsync();
        }

        // Seed blog posts if empty or fewer than 25
        if (!await _context.BlogPosts.AnyAsync() || await _context.BlogPosts.CountAsync() < 25)
        {
            _context.BlogPosts.RemoveRange(_context.BlogPosts);
            await _context.SaveChangesAsync();
            var rng = new Random();
            var allSeedPosts = new List<BlogPost>
            {
                new()
                {
                    Title = "UI/UX Design Trends That Will Define 2026",
                    Slug = "ui-ux-design-trends-2026",
                    Excerpt = "From AI-powered personalization to hyper-minimalist interfaces, the UX landscape is shifting fast. Discover the design trends that will shape digital experiences this year and how to apply them to your own projects.",
                    Content = "<h2>The Rise of AI-Driven Interfaces</h2><p>Artificial intelligence is no longer a futuristic concept — it is actively reshaping how users interact with digital products. In 2026, we are seeing AI move beyond chatbots and into adaptive interfaces that learn from user behavior in real time.</p><h3>Personalization at Scale</h3><p>Modern users expect experiences that feel tailor-made. AI allows designers to create interfaces that adjust layout, content, and navigation based on individual preferences without sacrificing aesthetic cohesion.</p><h2>Hyper-Minimalism and Micro-Interactions</h2><p>Less really is more. The trend toward minimal design continues, but with a new emphasis on micro-interactions that delight users at every touchpoint. Subtle hover states, animated transitions, and haptic feedback create a sense of polish.</p><p>Brands that invest in thoughtful micro-interactions see higher engagement and lower bounce rates. The key is restraint — every animation should serve a purpose.</p>",
                    ImageUrl = "https://picsum.photos/seed/uiux2026/800/450",
                    Author = "Jane Smith",
                    PublishedAt = new DateTime(2026, 6, 20),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Best Practices for Building Modern Mobile Apps",
                    Slug = "modern-mobile-app-development",
                    Excerpt = "Mobile app development continues to evolve with new tools and frameworks. Learn the essential practices every developer should follow to build fast, reliable, and user-friendly applications.",
                    Content = "<h2>Choosing the Right Architecture</h2><p>The foundation of any great mobile app is a solid architecture. Whether you choose MVVM, Clean Architecture, or MVI, consistency is key. A well-structured codebase makes feature additions and bug fixes significantly faster.</p><h3>Cross-Platform vs Native</h3><p>The debate between cross-platform frameworks like Flutter and React Native versus native development continues. Each approach has trade-offs in performance, development speed, and access to platform-specific features.</p><h2>Performance Optimization</h2><p>Users expect apps to launch in under two seconds. Strategies like lazy loading, efficient state management, and image caching are critical for delivering a smooth experience on both iOS and Android.</p><p>Regular profiling with tools like Xcode Instruments or Android Studio Profiler helps identify bottlenecks before they affect users.</p>",
                    ImageUrl = "https://picsum.photos/seed/mobileapp/800/450",
                    Author = "Alex Rivera",
                    PublishedAt = new DateTime(2026, 6, 5),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Digital Marketing Strategies That Actually Drive Growth",
                    Slug = "digital-marketing-strategies-growth",
                    Excerpt = "Not all marketing strategies deliver results. This post breaks down the data-backed approaches that consistently drive traffic, generate leads, and increase revenue for digital agencies.",
                    Content = "<h2>Content-Led Growth</h2><p>The most successful marketing campaigns start with great content. Blog posts, videos, and case studies that genuinely help your audience build trust and authority in your niche.</p><h3>SEO and Organic Reach</h3><p>Paid advertising is becoming more expensive, making organic reach more valuable than ever. A strong SEO strategy focused on user intent can deliver sustainable traffic for years.</p><h2>Conversion Rate Optimization</h2><p>Getting traffic is only half the battle. Converting that traffic into leads and customers requires careful A/B testing, clear calls-to-action, and frictionless user journeys. Small improvements in conversion rate can have outsized impacts on revenue.</p><p>Analyze your funnel regularly, identify drop-off points, and iterate relentlessly. The brands that win are the ones that never stop optimizing.</p>",
                    ImageUrl = "https://picsum.photos/seed/digitalmktg/800/450",
                    Author = "Sarah Chen",
                    PublishedAt = new DateTime(2026, 5, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Essential Graphic Design Tips for Non-Designers",
                    Slug = "graphic-design-tips-non-designers",
                    Excerpt = "You do not need a design degree to create visually appealing graphics. These practical tips will help anyone improve their layouts, color choices, and typography instantly.",
                    Content = "<h2>Master the Grid</h2><p>Every great design starts with a grid. Whether you are working on a social media graphic or a full website layout, aligning elements to a consistent grid creates visual harmony and makes your work look professional.</p><h3>Color Theory Made Simple</h3><p>Understanding complementary colors, contrast ratios, and color psychology can transform your designs. Stick to a palette of two to three primary colors and use accent colors sparingly for maximum impact.</p><h2>Typography Hierarchy</h2><p>The fastest way to improve any design is to fix the typography. Use no more than two typefaces, establish a clear hierarchy with size and weight, and pay attention to line height and letter spacing.</p><p>Good typography is invisible — it guides the reader's eye without calling attention to itself. When done right, the message feels effortless to consume.</p>",
                    ImageUrl = "https://picsum.photos/seed/graphicdesign/800/450",
                    Author = "John Doe",
                    PublishedAt = new DateTime(2026, 5, 10),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "The Complete Guide to Web Performance Optimization",
                    Slug = "web-performance-optimization-guide",
                    Excerpt = "Slow websites lose users and revenue. This comprehensive guide covers every technique you need to make your sites load faster, from image optimization to JavaScript bundling strategies.",
                    Content = "<h2>Measuring Performance</h2><p>Before optimizing, you need to measure. Core Web Vitals — LCP, FID, and CLS — are the industry standard metrics. Tools like Lighthouse and PageSpeed Insights provide actionable recommendations.</p><h3>Image Optimization</h3><p>Images account for over half of a typical page's weight. Using modern formats like WebP and AVIF, implementing lazy loading, and serving responsive images can cut load times dramatically.</p><h2>JavaScript and CSS Delivery</h2><p>Render-blocking resources are a major performance killer. Code splitting, tree shaking, and deferring non-critical scripts ensure that users see content as quickly as possible.</p><p>Server-side rendering and static generation can also significantly improve perceived performance for content-heavy sites.</p>",
                    ImageUrl = "https://picsum.photos/seed/webperf/800/450",
                    Author = "Priya Patel",
                    PublishedAt = new DateTime(2026, 4, 22),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "SEO for Agencies: How to Rank Your Clients Higher",
                    Slug = "seo-agencies-rank-higher",
                    Excerpt = "Ranking your clients in competitive markets requires a strategic approach. Learn the SEO tactics that agencies use to deliver measurable results across multiple industries.",
                    Content = "<h2>Technical SEO Foundations</h2><p>Before any content strategy can work, the technical foundation must be solid. Crawlability, indexation, site speed, and mobile responsiveness are non-negotiable for ranking success.</p><h3>Keyword Strategy at Scale</h3><p>Agencies managing multiple clients need efficient keyword research processes. Focus on topic clusters rather than individual keywords, and prioritize terms with clear commercial intent.</p><h2>Content and Link Building</h2><p>High-quality content and authoritative backlinks remain the strongest ranking signals. Develop content hubs around core topics and pursue guest posting, digital PR, and resource link building.</p><p>Consistency matters more than volume. Publishing one excellent article per week outperforms five mediocre ones.</p>",
                    ImageUrl = "https://picsum.photos/seed/seoagency/800/450",
                    Author = "John Doe",
                    PublishedAt = new DateTime(2026, 4, 8),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Content Writing for Brands: Finding Your Unique Voice",
                    Slug = "content-writing-brands-voice",
                    Excerpt = "In a crowded digital landscape, brand voice is your differentiator. Learn how to develop a distinctive writing style that resonates with your audience and builds lasting loyalty.",
                    Content = "<h2>Why Voice Matters</h2><p>Brands that sound like everyone else get ignored. A distinctive voice cuts through the noise and makes your audience feel like they are talking to a person, not a corporation. Consistency across every touchpoint builds recognition and trust.</p><h3>Defining Your Tone Spectrum</h3><p>Your tone should flex depending on context while staying true to your core voice. A tweet can be playful, a white paper authoritative, and a support email empathetic — all from the same brand.</p><h2>Storytelling Frameworks</h2><p>The most memorable brand content follows a narrative arc. Problem-agitation-solution, hero's journey, and before-after-bridge are proven frameworks that keep readers engaged from first sentence to call to action.</p><p>Great brand writing feels personal. Use \"you\" more than \"we\", share real stories, and don't be afraid to show vulnerability.</p>",
                    ImageUrl = "https://picsum.photos/seed/brandwriting/800/450",
                    Author = "Sarah Chen",
                    PublishedAt = new DateTime(2026, 3, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Social Media Strategy: Building Engagement That Lasts",
                    Slug = "social-media-strategy-engagement",
                    Excerpt = "Chasing likes and followers is a losing game. This post explains how to build a social media strategy focused on meaningful engagement, community growth, and measurable business outcomes.",
                    Content = "<h2>Platform Strategy</h2><p>Not every platform is right for every brand. Choose where your audience spends time and go deep rather than trying to be everywhere at once. A strong presence on two platforms beats a weak presence on six.</p><h3>Content Pillars</h3><p>Organize your social content around three to four core pillars — education, entertainment, inspiration, and promotion. This framework ensures variety while maintaining strategic focus.</p><h2>Community Management</h2><p>Engagement is a two-way street. Respond to comments, ask questions, and feature user-generated content. Brands that treat social media as a conversation rather than a broadcast channel see significantly higher loyalty.</p><p>Consistency in posting, authentic interactions, and data-driven content adjustments are the keys to sustained social media success.</p>",
                    ImageUrl = "https://picsum.photos/seed/socialstrat/800/450",
                    Author = "Jane Smith",
                    PublishedAt = new DateTime(2026, 3, 10),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Client Communication Tips Every Agency Should Know",
                    Slug = "client-communication-tips-agency",
                    Excerpt = "Strong client relationships are built on clear communication. Discover the frameworks and habits that top agencies use to keep clients informed, aligned, and delighted throughout every project.",
                    Content = "<h2>Setting Expectations Early</h2><p>Misalignment is the number one cause of client dissatisfaction. A well-written scope of work, clear milestones, and honest timelines prevent misunderstandings before they happen. Over-communicate early and often.</p><h3>The Weekly Check-In</h3><p>A brief weekly email or standup meeting keeps everyone aligned. Share what was accomplished, what is coming next, and any blockers. This simple habit builds trust and reduces surprise requests.</p><h2>Handling Feedback Gracefully</h2><p>Not all feedback is easy to hear. The best agencies listen without being defensive, ask clarifying questions, and present alternative solutions when client requests conflict with project goals.</p><p>Document every decision in writing. A shared decision log prevents \"we never agreed to that\" disputes and provides a valuable reference throughout the project.</p>",
                    ImageUrl = "https://picsum.photos/seed/clientcomm/800/450",
                    Author = "Alex Rivera",
                    PublishedAt = new DateTime(2026, 2, 20),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Remote Work Best Practices for Creative Teams",
                    Slug = "remote-work-creative-teams",
                    Excerpt = "Creative collaboration is harder when the team is distributed. Learn the tools, rituals, and management practices that keep remote creative teams productive, connected, and inspired.",
                    Content = "<h2>Asynchronous Communication</h2><p>Not everything needs a meeting. Written updates, recorded walkthroughs, and shared documents let team members contribute on their own schedules. This is especially important for creative work that requires deep focus.</p><h3>Virtual Collaboration Tools</h3><p>Figma, Miro, and Notion have become essential for remote creative teams. The key is tool discipline — define clear conventions for file organization, commenting, and version control to avoid chaos.</p><h2>Maintaining Team Culture</h2><p>Culture doesn't happen by accident in a remote environment. Regular virtual social events, peer recognition programs, and annual in-person meetups help maintain the human connections that drive great creative work.</p><p>The best remote teams invest intentionally in both synchronous connection time and asynchronous deep work periods.</p>",
                    ImageUrl = "https://picsum.photos/seed/remotework/800/450",
                    Author = "Priya Patel",
                    PublishedAt = new DateTime(2026, 2, 5),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "AI Tools for Designers: A Practical Guide",
                    Slug = "ai-tools-designers-guide",
                    Excerpt = "AI is transforming the design industry. From generative fill to automated wireframing, explore the tools that are changing how designers work and how to integrate them into your workflow.",
                    Content = "<h2>Generative Design Tools</h2><p>Tools like Midjourney, DALL-E, and Adobe Firefly have democratized visual creation. Designers can now generate mood boards, concept art, and even production assets in minutes rather than days.</p><h3>AI-Assisted Wireframing</h3><p>New tools can turn text prompts into functional wireframes and prototypes. While these outputs still need human refinement, they accelerate the early stages of the design process significantly.</p><h2>Ethical Considerations</h2><p>Using AI in design raises important questions about originality, copyright, and job displacement. The most successful designers treat AI as a collaborator, not a replacement — using it to handle repetitive tasks while focusing their energy on strategy and creativity.</p><p>The designers who thrive will be those who learn to prompt effectively, critique AI outputs critically, and bring uniquely human perspectives to their work.</p>",
                    ImageUrl = "https://picsum.photos/seed/aitools/800/450",
                    Author = "Jane Smith",
                    PublishedAt = new DateTime(2026, 1, 20),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Building a Strong Brand Identity from Scratch",
                    Slug = "building-strong-brand-identity",
                    Excerpt = "A great brand is more than a logo. This guide walks through the complete process of building a brand identity that communicates your values, differentiates you from competitors, and connects with your audience.",
                    Content = "<h2>Defining Your Brand Strategy</h2><p>Brand identity starts with strategy, not design. Define your mission, vision, values, target audience, and competitive positioning before creating any visual elements. These foundational decisions guide every design choice that follows.</p><h3>Visual Identity Systems</h3><p>A cohesive visual system includes logo variations, color palette, typography, iconography, and imagery guidelines. Each element should work independently and together to communicate your brand's personality consistently.</p><h2>Brand Guidelines and Consistency</h2><p>Document everything in a comprehensive brand guide. This ensures that anyone creating content for your brand — from designers to social media managers — maintains consistency across every touchpoint.</p><p>The strongest brands are those that apply their identity consistently across every channel while remaining flexible enough to evolve with their audience over time.</p>",
                    ImageUrl = "https://picsum.photos/seed/brandidentity/800/450",
                    Author = "John Doe",
                    PublishedAt = new DateTime(2026, 1, 5),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Mobile-First Design Principles Every Developer Should Know",
                    Slug = "mobile-first-design-principles",
                    Excerpt = "Mobile traffic now accounts for over 60% of all web traffic. Learn the core principles of mobile-first design and how to apply them to create experiences that work flawlessly on every screen size.",
                    Content = "<h2>Start with the Smallest Screen</h2><p>Mobile-first design means designing for the smallest screen first, then progressively enhancing for larger screens. This approach forces prioritization — you can only include what truly matters when space is limited.</p><h3>Touch Targets and Spacing</h3><p>Fingers are less precise than a mouse cursor. Buttons and interactive elements should be at least 48x48 pixels with adequate spacing to prevent accidental taps. This seemingly simple rule dramatically improves mobile usability.</p><h2>Performance Constraints</h2><p>Mobile devices often have slower network connections and less processing power. Optimizing images, minimizing JavaScript, and leveraging browser caching are essential practices that benefit all users regardless of device.</p><p>The best mobile experiences feel native — fast, responsive, and intuitive. Test on real devices, not just browser dev tools, to catch issues before they reach users.</p>",
                    ImageUrl = "https://picsum.photos/seed/mobilefirst/800/450",
                    Author = "Alex Rivera",
                    PublishedAt = new DateTime(2025, 12, 20),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Typography in Modern Web Design: A Complete Guide",
                    Slug = "typography-modern-web-design",
                    Excerpt = "Typography is the backbone of great web design. This guide covers everything from typeface selection to responsive type scales, helping you make informed typography decisions that elevate your projects.",
                    Content = "<h2>Choosing the Right Typeface</h2><p>Selecting a typeface is one of the most important design decisions you will make. Consider readability across devices, brand personality, and loading performance. Stick to two families maximum — one for headings and one for body text.</p><h3>Establishing a Type Scale</h3><p>A modular type scale creates visual harmony. Start with your body text size and use consistent ratios — typically 1.25 or 1.333 — to generate heading sizes. This mathematical approach ensures proportionality across all text elements.</p><h2>Responsive Typography</h2><p>Text that looks perfect on desktop may be illegible on mobile. Use fluid typography with clamp() in CSS to scale text smoothly between viewport sizes. Line length should stay between 50 and 75 characters for optimal readability.</p><p>Good typography is design that communicates. When readers never notice the type itself, you have done your job well.</p>",
                    ImageUrl = "https://picsum.photos/seed/typography/800/450",
                    Author = "John Doe",
                    PublishedAt = new DateTime(2025, 12, 5),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Color Psychology in Branding: How to Choose the Right Palette",
                    Slug = "color-psychology-branding-palette",
                    Excerpt = "Colors evoke emotions and influence decisions. Understand the psychology behind color choices and learn how to select a brand palette that communicates your values and resonates with your target audience.",
                    Content = "<h2>The Science of Color Perception</h2><p>Color is processed before words in the human brain. Studies show that people make subconscious judgments about a product within 90 seconds, and up to 90 percent of that assessment is based on color alone. Getting your palette right is critical.</p><h3>Color Meanings by Industry</h3><p>Blue conveys trust and is favored by financial institutions. Green represents growth and sustainability. Red creates urgency and is common in food and retail. Consider industry norms but do not be afraid to differentiate strategically.</p><h2>Building a Cohesive Palette</h2><p>A strong brand palette includes a primary color, secondary colors, and neutral tones. Follow the 60-30-10 rule — 60 percent dominant, 30 percent secondary, 10 percent accent — for balanced application across touchpoints.</p><p>Test your palette for accessibility. Ensure sufficient contrast ratios and consider how colors appear to users with color vision deficiencies.</p>",
                    ImageUrl = "https://picsum.photos/seed/colorpsych/800/450",
                    Author = "Sarah Chen",
                    PublishedAt = new DateTime(2025, 11, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "E-Commerce UX Best Practices That Boost Conversion Rates",
                    Slug = "ecommerce-ux-boost-conversions",
                    Excerpt = "A seamless shopping experience is the difference between a sale and an abandoned cart. Discover the UX patterns and design strategies that top e-commerce brands use to maximize conversions.",
                    Content = "<h2>Streamlined Checkout Flow</h2><p>Every extra field in your checkout form costs you customers. Implement guest checkout, auto-detect addresses, and offer multiple payment options. The fewer clicks to purchase, the higher your conversion rate.</p><h3>Product Page Optimization</h3><p>High-quality images from multiple angles, clear pricing, and social proof elements like reviews and ratings are essential. Include zoom functionality and size guides to reduce purchase hesitation and returns.</p><h2>Search and Navigation</h2><p>A robust search with autocomplete, filters, and faceted navigation helps users find products quickly. Categories should be intuitive and avoid jargon. Every second spent searching is an opportunity for the user to leave.</p><p>Personalized recommendations based on browsing history and purchase patterns can increase average order value by 10 to 30 percent when implemented thoughtfully.</p>",
                    ImageUrl = "https://picsum.photos/seed/ecommerceux/800/450",
                    Author = "Priya Patel",
                    PublishedAt = new DateTime(2025, 11, 10),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Video Marketing Strategies for Digital Agencies",
                    Slug = "video-marketing-digital-agencies",
                    Excerpt = "Video is the most engaging content format online. Learn how digital agencies can leverage video marketing across the customer journey — from awareness campaigns to testimonial content that closes deals.",
                    Content = "<h2>Types of Video Content</h2><p>Different stages of the funnel require different video formats. Short-form content works best for awareness on social platforms, while longer tutorials and case studies nurture leads. Live video builds authenticity and real-time connection.</p><h3>Production Without a Budget</h3><p>You do not need a professional studio to create effective video. Modern smartphones, good lighting, and quality audio equipment are sufficient for most content. Focus on clear messaging and genuine delivery over production polish.</p><h2>Distribution and Analytics</h2><p>Publish natively on each platform rather than sharing links. YouTube SEO, Instagram Reels algorithms, and LinkedIn video preferences all differ. Track completion rates and engagement metrics to refine your approach continuously.</p><p>Video content generates 1200 percent more shares than text and images combined. Agencies that make video a core part of their marketing strategy see significant competitive advantage.</p>",
                    ImageUrl = "https://picsum.photos/seed/videomktg/800/450",
                    Author = "Jane Smith",
                    PublishedAt = new DateTime(2025, 10, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Accessibility in Web Development: Building for Everyone",
                    Slug = "accessibility-web-development-everyone",
                    Excerpt = "Web accessibility is not optional — it is a fundamental right. Learn how to build websites that work for people of all abilities using semantic HTML, ARIA, and inclusive design practices.",
                    Content = "<h2>Semantic HTML as the Foundation</h2><p>Using proper HTML elements — nav, main, article, aside, button — provides built-in accessibility. Screen readers and other assistive technologies rely on correct document structure to navigate content meaningfully.</p><h3>ARIA and When to Use It</h3><p>ARIA attributes supplement HTML semantics but should not replace them. Use ARIA roles, states, and properties only when native HTML semantics are insufficient. Overusing ARIA can actually harm accessibility.</p><h2>Keyboard Navigation and Focus Management</h2><p>All interactive elements must be reachable and operable via keyboard. Visible focus indicators are essential. Custom components like modals and dropdowns require careful focus trapping and management to prevent users from getting stuck.</p><p>Accessibility benefits everyone — not just users with disabilities. Captions help people in noisy environments, high contrast helps in bright sunlight, and keyboard navigation helps power users move faster.</p>",
                    ImageUrl = "https://picsum.photos/seed/a11ydev/800/450",
                    Author = "David Kim",
                    PublishedAt = new DateTime(2025, 10, 10),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Microinteractions: Small Details That Make a Big Impact",
                    Slug = "microinteractions-big-impact",
                    Excerpt = "The difference between a good product and a great one often comes down to the details. Explore how microinteractions — subtle animations, haptic feedback, and responsive states — create delightful user experiences.",
                    Content = "<h2>What Makes a Microinteraction</h2><p>A microinteraction has four parts: trigger, rules, feedback, and loops and modes. The trigger initiates the interaction, the rules define what happens, the feedback communicates the result, and loops determine repetition.</p><h3>Examples That Delight</h3><p>The like animation on Twitter, the pull-to-refresh on iOS, and the subtle bounce when switching between apps — these small moments create emotional connections. Users may not notice them consciously, but they feel their absence.</p><h2>Implementation Best Practices</h2><p>Microinteractions should be fast — under 300 milliseconds — and serve a clear purpose. Avoid animation for its own sake. Each microinteraction should communicate status, provide visual feedback, or prevent errors.</p><p>Products with thoughtful microinteractions see higher engagement and lower error rates. The investment in these small details pays dividends in user satisfaction and retention.</p>",
                    ImageUrl = "https://picsum.photos/seed/microinteract/800/450",
                    Author = "Maya Torres",
                    PublishedAt = new DateTime(2025, 9, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "API Integration Best Practices for Modern Web Applications",
                    Slug = "api-integration-web-apps",
                    Excerpt = "APIs are the glue that connects modern software. This guide covers best practices for integrating third-party APIs — from authentication and error handling to rate limiting and caching strategies.",
                    Content = "<h2>Authentication and Security</h2><p>Never expose API keys on the client side. Use environment variables for server-side keys and implement token-based authentication like OAuth 2.0 for user-facing integrations. Rotate keys regularly and audit access logs.</p><h3>Error Handling and Resilience</h3><p>APIs fail — networks timeout, services go down, rate limits are exceeded. Implement exponential backoff retry logic, graceful degradation, and meaningful error messages. Circuit breakers prevent cascading failures across your system.</p><h2>Performance Optimization</h2><p>Cache API responses aggressively using ETags, conditional requests, and in-memory caches. Batch requests when possible and consider GraphQL for complex data requirements. Monitor response times and set up alerts for degradation.</p><p>Well-designed API integrations feel seamless to users. The complexity of the underlying communication should be invisible — fast, reliable, and secure by default.</p>",
                    ImageUrl = "https://picsum.photos/seed/apiintegration/800/450",
                    Author = "Alex Rivera",
                    PublishedAt = new DateTime(2025, 9, 10),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Building Design Systems and Component Libraries That Scale",
                    Slug = "design-systems-component-libraries",
                    Excerpt = "Design systems are the foundation of consistent, scalable product development. Learn how to build and maintain a design system that empowers your team to ship faster with fewer inconsistencies.",
                    Content = "<h2>Tokens and Foundations</h2><p>Design tokens are the atomic building blocks of a design system — colors, typography, spacing, and shadows stored as named values. Tokens ensure consistency across platforms and make global updates possible with a single change.</p><h3>Component Architecture</h3><p>Build components following a single responsibility principle. Each component should do one thing well, accept props for customization, and be thoroughly documented with usage examples, variants, and states.</p><h2>Governance and Adoption</h2><p>A design system is only valuable if teams actually use it. Establish clear contribution guidelines, version components semantically, and provide tooling that makes integration frictionless. Regular office hours and demos encourage adoption.</p><p>The best design systems evolve with the products they serve. They are living documents that balance consistency with flexibility, enabling teams to move fast without breaking the visual experience.</p>",
                    ImageUrl = "https://picsum.photos/seed/designsystems/800/450",
                    Author = "Jane Smith",
                    PublishedAt = new DateTime(2025, 8, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Freelancing vs Agency Life: Which Is Right for You?",
                    Slug = "freelancing-vs-agency-life",
                    Excerpt = "Choosing between freelancing and working at an agency is one of the biggest career decisions for creative professionals. Compare the pros and cons of each path to find the right fit for your goals and lifestyle.",
                    Content = "<h2>The Freelancer Advantage</h2><p>Freelancing offers unparalleled freedom — choose your clients, set your schedule, and keep a larger share of your earnings. The trade-off is inconsistent income, the burden of administration, and the isolation of working alone.</p><h3>Agency Structure and Growth</h3><p>Agencies provide stable income, structured career progression, and opportunities to work on larger, more complex projects. You gain exposure to diverse industries and benefit from team collaboration and mentorship.</p><h2>Financial Considerations</h2><p>Freelancers must handle their own taxes, insurance, and retirement planning. Agency employees enjoy benefits and predictable paychecks but typically earn less per hour than successful freelancers charging premium rates.</p><p>Many creative professionals find success in a hybrid model — freelancing for flexibility while maintaining retainer relationships with agencies for stability. The key is knowing yourself and what environment brings out your best work.</p>",
                    ImageUrl = "https://picsum.photos/seed/freelanceagency/800/450",
                    Author = "Maya Torres",
                    PublishedAt = new DateTime(2025, 8, 10),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "How to Write a Creative Brief That Gets Results",
                    Slug = "write-creative-brief-results",
                    Excerpt = "A great creative brief is the blueprint for outstanding work. Learn how to write briefs that inspire creativity, align stakeholders, and provide clear direction without stifling the creative process.",
                    Content = "<h2>The Anatomy of a Brief</h2><p>Every creative brief should include the project background, target audience, key message, deliverables, timeline, and budget. The best briefs are concise — one page is ideal — and focused on outcomes rather than execution details.</p><h3>Writing for Inspiration</h3><p>Briefs should motivate, not dictate. Use evocative language that paints a picture of the desired outcome. Include reference points, mood boards, or competitor examples to convey direction without prescribing solutions.</p><h2>Avoiding Common Pitfalls</h2><p>The most common brief mistakes are being too vague, too prescriptive, or cramming too many objectives into a single project. A clear hierarchy of goals helps the creative team prioritize what truly matters.</p><p>A well-written brief saves time and money by reducing revision cycles. The hour spent writing a thorough brief often saves days of back-and-forth during the creative development phase.</p>",
                    ImageUrl = "https://picsum.photos/seed/creativebrief/800/450",
                    Author = "David Kim",
                    PublishedAt = new DateTime(2025, 7, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "Landing Page Conversion Tips That Double Your Leads",
                    Slug = "landing-page-conversion-double-leads",
                    Excerpt = "Your landing page is often the first impression potential customers have of your business. Apply these proven conversion optimization techniques to turn more visitors into qualified leads.",
                    Content = "<h2>Above the Fold Clarity</h2><p>Visitors decide whether to stay or leave within seconds. Your headline must clearly communicate the unique value proposition, and your primary call to action should be visible without scrolling. Remove navigation links that distract from the conversion goal.</p><h3>Social Proof and Urgency</h3><p>Testimonials, case study logos, and trust badges reduce anxiety and build credibility. Limited-time offers and countdown timers create urgency, but use them honestly — false urgency erodes trust over time.</p><h2>Form Optimization</h2><p>Every field you add reduces conversion rate. Ask only for essential information and consider multi-step forms for longer conversions. Inline validation, clear error messages, and privacy reassurances reduce form abandonment.</p><p>Continuous A/B testing is the secret to sustained improvement. Test headlines, button colors, images, and form lengths systematically. Small changes can produce outsized results when driven by data.</p>",
                    ImageUrl = "https://picsum.photos/seed/landingpage/800/450",
                    Author = "John Doe",
                    PublishedAt = new DateTime(2025, 7, 10),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                },
                new()
                {
                    Title = "The Future of AI in Creative Work: Opportunities and Challenges",
                    Slug = "future-ai-creative-work",
                    Excerpt = "AI is reshaping creative industries at an unprecedented pace. Explore the opportunities AI presents for creative professionals and the challenges that need to be addressed as the technology evolves.",
                    Content = "<h2>Augmenting Human Creativity</h2><p>AI excels at pattern recognition, data processing, and generating variations — tasks that are time-consuming for humans. By handling these repetitive aspects, AI frees creative professionals to focus on strategy, concept development, and emotional storytelling.</p><h3>New Creative Roles</h3><p>Prompt engineering, AI art direction, and ethical AI consulting are emerging as distinct roles. Creative professionals who develop skills in directing and curating AI outputs will be in high demand as the technology matures.</p><h2>Ethical and Legal Challenges</h2><p>Copyright, attribution, and bias remain unresolved issues in AI-generated content. Clear regulations are needed to protect original creators while enabling innovation. Agencies must develop ethical frameworks for AI use that prioritize transparency.</p><p>The future belongs to those who embrace AI as a collaborator rather than fear it as a competitor. Human creativity amplified by artificial intelligence will produce work that neither could achieve alone.</p>",
                    ImageUrl = "https://picsum.photos/seed/aifuture/800/450",
                    Author = "Sarah Chen",
                    PublishedAt = new DateTime(2025, 6, 25),
                    IsPublished = true,
                    Views = rng.Next(120, 4500)
                }
            };
            _context.BlogPosts.AddRange(allSeedPosts);
            await _context.SaveChangesAsync();
        }

        var vm = new HomeViewModel
        {
            Services = await _context.Services.ToListAsync(),
            Projects = (await _context.Projects.Where(p => p.IsPublished).ToListAsync()).OrderBy(_ => Guid.NewGuid()).Take(3).ToList(),
            Testimonials = await _context.Testimonials.ToListAsync(),
            Faqs = await _context.FaqItems.Where(f => f.IsActive).OrderBy(f => f.Order).ToListAsync(),
            BlogPosts = (await _context.BlogPosts.Where(p => p.IsPublished).ToListAsync()).OrderBy(_ => Random.Shared.Next()).Take(3).ToList()
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitContact(HomeViewModel model)
    {
        if (ModelState.IsValid)
        {
            _context.ContactMessages.Add(model.Contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { success = true });
        }
        return RedirectToAction(nameof(Index), new { error = true });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
