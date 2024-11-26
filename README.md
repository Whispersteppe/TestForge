# TestForge
TestForge is a test suite for .Net core, to allow a developer to better test their applications
before releasing them into the cold cruel world

## Current Build Status

![Build Status](https://github.com/whispersteppe/testforge/actions/workflows/dotnet.yml/badge.svg)

# Data Generation

Generation of random data

Consistent and repeatable generation of data

Reporting of what data was generated


# Test Integration

## XUnit
To better help with using the data generation, we need to feed it into tests.  What better 
way than using XUnits Theory and DataClass attributes to further this aim? By extending some 
of these classes and simplifying how data is created (and using our data generation classes)
we can easily test a large quantity of random scenarios under the developers control, and 
when it does fail, set up and test just a particular scenario using the appropriate seed data.

# Future Directions

##  Test Generation
Sometimes you need to create tests, but didn't quite see those edge cases.  So why not let 
a chunk of software come through and find all the test casts it can for you?  
## Mutation Testing
If something changes in your code, can you see where it has changed?  sometimes something 
as small as a missed conditional or an inverted add could throw everything off.
##  Documentation
The bane of seemingly every developers existence.  Oh, just go read the code, they say, 
it's the only accurate source of truth out there.  But finding what the code is supposed 
to do is step one in this.  getting usable documentation out there so that someone can 
understand what is where and how it relates to the application as a whole
## Mocking
I'll just say it - Mocks are cool, and I'm a great fan of Moq.  So I'd like to make sure 
that anything we're doing here is integrated properly