﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vocap.Infrastructure;

#nullable disable

namespace Vocap.Infrastructure.Migrations
{
    [DbContext(typeof(VocabularyContext))]
    partial class VocabularyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("vocap")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vocap.Domain.AggregatesModel.VocabularyAggreate.Vocabulary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DaftWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Definetion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WorkFlowOfVocabulary")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("vocabularies", "vocap");
                });

            modelBuilder.Entity("Vocap.Domain.AggregatesModel.VocabularyAggreate.Vocabulary", b =>
                {
                    b.OwnsOne("Vocap.Domain.AggregatesModel.VocabularyAggreate.CamVocabulary", "CamVocabulary", b1 =>
                        {
                            b1.Property<int>("VocabularyId")
                                .HasColumnType("integer");

                            b1.Property<string>("Audio")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("DaftWord")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Phonetic")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("WordType")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VocabularyId");

                            b1.ToTable("vocabularies", "vocap");

                            b1.WithOwner()
                                .HasForeignKey("VocabularyId");
                        });

                    b.OwnsOne("Vocap.Domain.AggregatesModel.VocabularyAggreate.VietnamMeaning", "VietnamMeaning", b1 =>
                        {
                            b1.Property<int>("VocabularyId")
                                .HasColumnType("integer");

                            b1.Property<string>("Meaning")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VocabularyId");

                            b1.ToTable("vocabularies", "vocap");

                            b1.WithOwner()
                                .HasForeignKey("VocabularyId");
                        });

                    b.Navigation("CamVocabulary")
                        .IsRequired();

                    b.Navigation("VietnamMeaning")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}