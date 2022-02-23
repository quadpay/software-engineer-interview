# Zip Software Engineer Interview

## Overview

Zip is a payment gateway that lets consumers split purchases into 4 interest free installments, every two weeks. The first 25% is taken when the purchase is made, and the remaining 3 installments of 25% are automatically taken every 14 days. We help customers manage their cash-flow while helping merchants increase conversion rates and average order values.

It may help to see our [product in action online](https://www.fanatics.com/mlb/new-york-yankees/new-york-yankees-nike-home-replica-custom-jersey-white/o-8976+t-36446587+p-2520909211+z-8-3193055640?_ref=p-CLP:m-GRID:i-r0c1:po-1), checkout our app on [ios](https://apps.apple.com/us/app/quadpay-buy-now-pay-later/id1425045070) or [android](https://play.google.com/store/apps/details?id=com.quadpay.quadpay&hl=en_US), and to read our documentation (https://docs.us.zip.co).

## Background

One of the cornerstones of Zip's culture is openness and transparency. When reviewing our existing interview structure, we found that pair-programming challenges rarely replicated what our employees actually do in their day-to-day work. For example, when was the last time you coded without google, or when the requirements weren't clearly defined? To tackle that, we've decided to publish our pair programming interview and share it directly with candidates beforehand.

As an Engineer at Zip you’ll help solve interesting problems on a daily basis. Some areas that you'll work on include fraud prevention, building real-time credit-decisioning models and, most importantly, shipping products that are secure, frictionless, and deliver a high-quality consumer experience.

The pair programming challenge will take an hour, and will more closely replicate a day-in-the-life at Zip. You’re free to use whichever resources help you to get the job done. When we evaluate your code at the end of the session, we will be looking for: 
- A high code health
- Simplicity
- Readability
- Presence of tests or planning for future tests
- And maintainability

While we mainly use .NET and C# in our back-end, we welcome candidates who are more familiar with other languages. We ask that you simply confirm your language with your recruiter beforehand. At the moment, we have only finalized starter code for C#, but feel free to look through that to prepare for your assignment even if using another language.

## The Pair Programming Interview

### The Challenge

During the interview, you will build a core service for our business, an Installment Calculator. There is no need to build anything before the interview, but feel free to investigate the boilerplate code and do some research on how you would set this up.

#### Installment Calculator
##### User Story

As a Zip Customer, I would like to establish a payment plan spread over 6 weeks that splits the original charge evenly over 4 installments.

##### Acceptance Criteria
- Given it is the 1st of January, 2020
- When I create an order of $100.00
- And I select 4 Installments
- And I select a frequency of 14 days
- Then I should be charged these 4 installments
  - `01/01/2020   -   $25.00`
  - `01/15/2020   -   $25.00`
  - `01/29/2020   -   $25.00`
  - `02/12/2020   -   $25.00`

## The System Design Interview

### Tools

For the system design interview, you are free to choose whatever tool you'd like. Our default is [Google Jamboard](https://edu.google.com/products/jamboard/?modal_active=none). If you have no preference on what tool you'd like to use, we recommend playing around with the jamboard a bit beforehand to learn the tips and tricks. Most interviewers find it's easier to use the stickynotes or textbox functions with drawn lines/arrows linking them together. If you prefer pen and paper or a whiteboard and marker, that's totally fine, just make sure your interviewer is able to see them every now and then if you're remote.

### Resources

There is absolutely no expectation for you to buy any books or online courses beforehand. Some of the following are links to resources that upsell to a paid course, but the free content should be good enough:

- [Grokking the System Design Interview - Build a URL Shortener](https://www.educative.io/courses/grokking-the-system-design-interview/m2ygV4E81AR)
- [System Design at Google](https://www.quora.com/What-is-the-system-design-interview-at-Google-like-for-a-SWE-position)

While we won't give you the exact prompt ahead of time, our general recommendation for all of our system design interviews is to:

- Ask questions
- Think about scalability
- Don't be afraid to completely change your design halfway through

## Closing Thoughts

We very much look forward to meeting you. Our goal is to make interviewers feel comfortable and prepared, so always feel free to reach out to your recruiter if you have any questions. Afterward, we welcome any and all feedback. We're constantly iterating and improving this process, and anything you share will help us make our interviews better for future candidates.
