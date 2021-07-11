using AutoMapper.QueryableExtensions;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Filters;

namespace WebFramework.Api
{
    //[ApiVersion("1")]
    public class CrudController<TListDto, TDetailDto, TCreateDto, TUpdateDto, TEntity, TKey> : BaseController
        where TListDto : BaseDto<TListDto, TEntity, TKey>, new()
        where TDetailDto : BaseDto<TDetailDto, TEntity, TKey>, new()
        where TCreateDto : BaseDto<TCreateDto, TEntity, TKey>, new()
        where TUpdateDto : BaseDto<TUpdateDto, TEntity, TKey>, new()
        where TEntity : BaseEntity<TKey>, new()
    {
        private readonly IRepository<TEntity> _repository;

        public CrudController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TListDto>>> Index(CancellationToken cancellationToken)
        {
            var list = await _repository.TableNoTracking.ProjectTo<TListDto>()
                .ToListAsync(cancellationToken);

            return View(list);
        }

        [HttpGet]
        public virtual async Task<ActionResult<TDetailDto>> Detail(TKey id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<TDetailDto>()
                .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

            if (dto == null)
                return NotFound();

            return View(dto);
        }

        [HttpGet]
        public virtual async Task<ActionResult<TListDto>> Create(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<ActionResult<TListDto>> Create(TCreateDto dto, CancellationToken cancellationToken)
        {
            var model = dto.ToEntity();

            await _repository.AddAsync(model, cancellationToken);

            var resultDto = await _repository.TableNoTracking.ProjectTo<TListDto>().SingleOrDefaultAsync(p => p.Id.Equals(model.Id), cancellationToken);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual async Task<ActionResult<TUpdateDto>> Edit(TKey id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<TUpdateDto>()
                .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

            if (dto == null)
                return NotFound();

            return View(dto);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TListDto>> Edit(TKey id, TUpdateDto dto, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, id);

            model = dto.ToEntity(model);

            await _repository.UpdateAsync(model, cancellationToken);
            
            return RedirectToAction("Detail",new { id = id });
        }

        [HttpGet]
        public virtual async Task<ActionResult> Delete(TKey id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, id);

            await _repository.DeleteAsync(model, cancellationToken);

            return RedirectToAction("Index");
        }
    }

    public class CrudController<TListDto, TDetailDto, TCreateDto, TUpdateDto, TEntity> : CrudController<TListDto, TDetailDto, TCreateDto, TUpdateDto, TEntity, int>
        where TListDto : BaseDto<TListDto, TEntity, int>, new()
        where TDetailDto : BaseDto<TDetailDto, TEntity, int>, new()
        where TCreateDto : BaseDto<TCreateDto, TEntity, int>, new()
        where TUpdateDto : BaseDto<TUpdateDto, TEntity, int>, new()
        where TEntity : BaseEntity<int>, new()
    {
        public CrudController(IRepository<TEntity> repository)
            : base(repository)
        {
        }
    }

    public class CrudController<TListDetailDto, TCreateDto, TUpdateDto, TEntity> : CrudController<TListDetailDto, TListDetailDto, TCreateDto, TUpdateDto, TEntity, int>
        where TListDetailDto : BaseDto<TListDetailDto, TEntity, int>, new()
        where TCreateDto : BaseDto<TCreateDto, TEntity, int>, new()
        where TUpdateDto : BaseDto<TUpdateDto, TEntity, int>, new()
        where TEntity : BaseEntity<int>, new()
    {
        public CrudController(IRepository<TEntity> repository)
            : base(repository)
        {
        }
    }
    public class CrudController<TListDetailDto, TCreateUpdateDto, TEntity> : CrudController<TListDetailDto, TListDetailDto, TCreateUpdateDto, TCreateUpdateDto, TEntity, int>
       where TListDetailDto : BaseDto<TListDetailDto, TEntity, int>, new()
       where TCreateUpdateDto : BaseDto<TCreateUpdateDto, TEntity, int>, new()       
       where TEntity : BaseEntity<int>, new()
    {
        public CrudController(IRepository<TEntity> repository)
            : base(repository)
        {
        }
    }

    public class CrudController<TDto, TEntity> : CrudController<TDto, TDto, TDto, TDto, TEntity, int>
        where TDto : BaseDto<TDto, TEntity, int>, new()
        where TEntity : BaseEntity<int>, new()
    {
        public CrudController(IRepository<TEntity> repository)
            : base(repository)
        {
        }
    }
}
