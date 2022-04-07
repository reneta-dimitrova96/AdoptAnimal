﻿namespace AdoptAnimal.Web.ViewModels.Articles
{
    using System;
    using System.Linq;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AutoMapper;

    public class GetArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Source { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, GetArticleViewModel>()
                .ForMember(
                    a => a.Source, opt => opt.MapFrom(a =>
                    a.ArticleImage.Source != null ?
                    a.ArticleImage.Source :
                    string.Empty));
        }
    }
}
