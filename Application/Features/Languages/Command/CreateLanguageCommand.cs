using Application.Features.Languages.Dtos;
using Application.IRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Languages.Command
{
    public class CreateLanguageCommand : IRequest<ILanguageDto>
    {
        public class CreateLanguageCommandHandle : IRequestHandler<CreateLanguageCommand, ILanguageDto>
        {
            private readonly ILanguageRepository _languageRepositor;
            private readonly IMapper _mapper;

            public CreateLanguageCommandHandle(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepositor = languageRepository;
                _mapper = mapper;
            }

            public async Task<ILanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language mappedlanguage = _mapper.Map<Language>(request);
                Language createdLanguage = await _languageRepositor.AddAsync(mappedlanguage);
                ILanguageDto createdLanguageDto = _mapper.Map<ILanguageDto>(createdLanguage);
                return createdLanguageDto;
            }

        }
    }
}
