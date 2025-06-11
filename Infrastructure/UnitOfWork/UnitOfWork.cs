using Application.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
namespace Infrastructure.UnitOfWork
{
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FirstActivityDbContext _context;

    private ICategories_catalogRepository? _categories_catalogs;
    private ICategory_optionRepository? _category_options;
    private IChapterRepository? _chapters;
    private IOption_questionRepository? _option_questions;
    private IOptions_responseRepository? _options_responses;
    private IQuestionRepository? _questions;
    private ISub_questionRepository? _sub_questions;
    private ISummary_optionRepository? _summary_options;
    private ISurveyRepository? _surveys;
    private IMemberRepository _member;
    private IRolRepository _rol;

    public UnitOfWork(FirstActivityDbContext context)
        {
            _context = context;
        }

    public ICategories_catalogRepository Categories_catalogs
    {
        get
        {
            if (_categories_catalogs == null)
            {
                _categories_catalogs = new Categories_catalogRepository(_context);
            }
            return _categories_catalogs;
        }
    }

    public ICategory_optionRepository Category_options
    {
        get
        {
            if (_category_options == null)
            {
                _category_options = new Category_optionRepository(_context);
            }
            return _category_options;
        }
    }

    public IChapterRepository Chapters
    {
        get
        {
            if (_chapters == null)
            {
                _chapters = new ChapterRepository(_context);
            }
            return _chapters;
        }
    }

    public IOption_questionRepository Option_questions
    {
        get
        {
            if (_option_questions == null)
            {
                _option_questions = new Option_questionRepository(_context);
            }
            return _option_questions;
        }
    }

    public IOptions_responseRepository Options_responses
    {
        get
        {
            if (_options_responses == null)
            {
                _options_responses = new Options_responseRepository(_context);
            }
            return _options_responses;
        }
    }

    public IQuestionRepository Questions
    {
        get
        {
            if (_questions == null)
            {
                _questions = new QuestionRepository(_context);
            }
            return _questions;
        }
    }

    public ISub_questionRepository Sub_questions
    {
        get
        {
            if (_sub_questions == null)
            {
                _sub_questions = new Sub_questionRepository(_context);
            }
            return _sub_questions;
        }
    }

    public ISummary_optionRepository Summary_options
    {
        get
        {
            if (_summary_options == null)
            {
                _summary_options = new Summary_optionRepository(_context);
            }
            return _summary_options;
        }
    }

    public ISurveyRepository Surveys
    {
        get
        {
            if (_surveys == null)
            {
                _surveys = new SurveyRepository(_context);
            }
            return _surveys;
        }
    }
    
    public IMemberRepository Members
    {
        get
        {
            if (_member == null)
            {
                _member = new MemberRepository(_context);
            }
            return _member;
        }
    }
    public IRolRepository Roles
    {
        get
        {
            if (_rol == null)
            {
                _rol = new RolRepository(_context);
            }
            return _rol;
        }
    }

    public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    public void Dispose()
    {
        _context.Dispose();
    }
}
}